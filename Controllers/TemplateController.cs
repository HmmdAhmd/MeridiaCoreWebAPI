using MeridiaCoreWebAPI.Models;
using MeridiaCoreWebAPI.Core;
using MeridiaCoreWebAPI.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MeridiaCoreWebAPI.ViewModels.CloudStorage;
using MeridiaCoreWebAPI.ViewModels.Template;
using System.Collections.Concurrent;
using MeridiaCoreWebAPI.Constants;
using Microsoft.AspNetCore.Authorization;
using OpenIddict.Validation.AspNetCore;
using MeridiaCoreWebAPI.Authorization;

namespace MeridiaCoreWebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme, Policy = Policies.OperatorRolePolicy)]
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private TemplateCore _templateCore;
        private UtilityFunctions _utilityFunctions;
        private UserManager<ApplicationUser> _userManager;
        private SubscriptionCore _subscriptionCore;
        private ParticipantManagementCore _participantManagementCore;

        public TemplateController(UserManager<ApplicationUser> userManager, TemplateCore templateCore, UtilityFunctions utilityFunctions,
            SubscriptionCore subscriptionCore, ParticipantManagementCore participantManagementCore)
        {
            _userManager = userManager;
            _templateCore = templateCore;
            _utilityFunctions = utilityFunctions;
            _subscriptionCore = subscriptionCore;
            _participantManagementCore = participantManagementCore;
        }

        [Route("list/chunk")]
        [HttpPost]
        public async Task<JsonResult> GetTemplatesChunk([FromBody] TemplateFilter tf)
        {
            List<TemplateGetViewModel> templatesList = new List<TemplateGetViewModel>();
            try
            {
                string userId = _userManager.GetUserId(User);

                List<string> userIds = new List<string>();
                List<int> templateIdsToFetch = new List<int>();

                if (!string.IsNullOrEmpty(userId))
                {
                    Subscription subscription = _subscriptionCore.GetSubscriptionByUserId(userId);

                    userIds.Add(subscription.UserId);

                    if (subscription.SubscriptionTypeId == (int)Enums.SubscriptionTypes.Parent)
                    {
                        userIds.AddRange(_subscriptionCore.GetChildUserIdsByMasterId(subscription.SubscriptionId));
                    }

                    templateIdsToFetch.AddRange(_templateCore.GetTemplateIdsByUserIds(userIds, tf.IsArchived));
                    
                    if (subscription.SubscriptionTypeId == (int)Enums.SubscriptionTypes.Child)
                    {
                        templateIdsToFetch.AddRange(_templateCore.GetSharedTemplateIds(subscription.SubscriptionId, subscription.ParentId.Value));
                    }

                    List<int> filteredTemplateIds = _templateCore.GetTemplatesIdsByIdsFilter(templateIdsToFetch, tf);

                    List<Template> templates = _templateCore.GetTemplatesInfoByIds(filteredTemplateIds);

                    List<Subscription> childSubs = _subscriptionCore.GetChildSubscriptionsByMasterId(subscription.SubscriptionId);
                    
                    Dictionary<string, string> subUserIdNameDictionary = childSubs.ToDictionary(x => x.UserId, x => x.AccessKey);

                    foreach (var template in templates)
                    {
                        TemplateGetViewModel tgvm = new TemplateGetViewModel();
                        tgvm = (TemplateGetViewModel)_utilityFunctions.MapFields(template, tgvm);

                        if (template.Slides.Count > 0)
                        {
                            tgvm.SlideImageURL = template.Slides.SingleOrDefault(x => x.SlideOrdinal == 1).URL;
                            tgvm.SlidesCount = template.Slides.Count;
                        }

                        tgvm.TemplateTags = new List<TemplateTagGetViewModel>();

                        if (template.TemplateTags != null)
                        {
                            foreach (var templateTag in template.TemplateTags)
                            {
                                TemplateTagGetViewModel ttgvm = new TemplateTagGetViewModel();
                                ttgvm = (TemplateTagGetViewModel)_utilityFunctions.MapFields(templateTag, ttgvm);
                                ttgvm.Name = templateTag.Tag.Name;
                                tgvm.TemplateTags.Add(ttgvm);
                            }
                        }

                        if ((template.TemplateMetaData != null))
                        {
                            tgvm.MetaDataString = string.Join(" | ", template.TemplateMetaData.Select(tm => tm.MetaDataKey.ToUpper() + "=" +
                            tm.MetaDataValue.ToUpper()).ToList());
                            tgvm.MetaDataString = tgvm.MetaDataString.Replace("PASS/FAIL with a grade".ToUpper(), "PASS/FAIL @ 80% with a grade"
                                .ToUpper());
                            tgvm.MetaDataString = tgvm.MetaDataString.Replace("PASS/FAIL with a grade 100".ToUpper(),
                                "PASS/FAIL @ 100% with a grade".ToUpper());
                        }

                        if (string.IsNullOrEmpty(subscription.Timezone) == false & subscription.Timezone != "UTC")
                        {
                            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(subscription.Timezone);
                            template.CreatedDate = TimeZoneInfo.ConvertTimeFromUtc(template.CreatedDate, tzi);
                            template.LastModifiedDate = TimeZoneInfo.ConvertTimeFromUtc(template.LastModifiedDate, tzi);
                        }

                        List<string> groupNames = new List<string>();
                        groupNames = _participantManagementCore.GetParticipantGroupNamesByTemplateId(tgvm.TemplateId, userId);
                        
                        foreach (var name in groupNames)
                        {
                            tgvm.AssociatedGroupsString += name + ", ";
                        }
                        tgvm.AssociatedGroupsString = tgvm.AssociatedGroupsString.Trim().Trim(',');

                        if (subscription.SubscriptionTypeId == (int)Enums.SubscriptionTypes.Parent)
                        {
                            if (template.UserId.Equals(subscription.UserId))
                                tgvm.UploadedByString = "uploaded by: myself";
                            else
                            {
                                if (subUserIdNameDictionary.ContainsKey(tgvm.UserId))
                                    tgvm.UploadedByString = "uploaded by: " + subUserIdNameDictionary[tgvm.UserId];
                                else
                                    tgvm.UploadedByString = "child";
                            }

                            tgvm.IsEditable = true;
                            tgvm.IsShareable = true;
                        }
                        else
                        {
                            tgvm.IsShareable = false;
                            if (template.UserId.Equals(subscription.UserId))
                            {
                                tgvm.UploadedByString = "uploaded by: myself";
                                tgvm.IsEditable = true;
                            }
                            else
                            {
                                tgvm.UploadedByString = "shared";
                                tgvm.IsEditable = false;
                            }
                        }

                        templatesList.Add(tgvm);
                    }

                    Parallel.ForEach(new ConcurrentBag<TemplateGetViewModel>(templatesList), template =>
                    {
                        CloudBlobBlockAccessUrlViewModel cloudBlobBlockAccessUrlViewModel = new CloudBlobBlockAccessUrlViewModel()
                        {
                            ImageUrl = template.SlideImageURL,
                            RootDirectory = AzureConstants.ROOT_DIRECTORY_NAME,
                            UserId = userId,
                            SubDirectoryLevelOne = template.TemplateId.ToString(),
                            URLExpiryDate = DateTime.UtcNow.AddDays(3)
                        };
                        template.SlideImageURL = "https://img.freepik.com/free-vector/simple-blue-gradient-background-vector-business_53876-143439.jpg";
                    });
                }

                return _utilityFunctions.ReturnResponse(templatesList, ResponseType.SUCCESS, ResponseType.SUCCESS);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
