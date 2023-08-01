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
using MeridiaCoreWebAPI.ViewModels;
using MeridiaCoreWebAPI.ViewModels.Polling;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace MeridiaCoreWebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme, Policy = Policies.OperatorRolePolicy)]
    [Route("api/[controller]")]
    [ApiController]
    public class PollingController : ControllerBase
    {
        private TemplateCore _templateCore;
        private UtilityFunctions _utilityFunctions;
        private UserManager<ApplicationUser> _userManager;
        private SubscriptionCore _subscriptionCore;
        private PollingCore _pollingCore;

        public PollingController(UserManager<ApplicationUser> userManager, TemplateCore templateCore, UtilityFunctions utilityFunctions,
            SubscriptionCore subscriptionCore, PollingCore pollingCore)
        {
            _userManager = userManager;
            _utilityFunctions = utilityFunctions;
            _subscriptionCore = subscriptionCore;
            _pollingCore = pollingCore;
        }

        [Route("data/list/chunk")]
        [HttpPost]
        public JsonResult GetPollingSessinsChunk([FromBody] Filter pf)
        {
            List<PollingDataGetViewModel> lpdgvm = new List<PollingDataGetViewModel>();
            try
            {
                string userId = _userManager.GetUserId(User);

                List<string> userIds = new List<string>();
                List<int> pollingSessionIdsToFetch = new List<int>();
                List<int> sharedTemplateIds = new List<int>();

                if (!string.IsNullOrEmpty(userId))
                {
                    Subscription subscription = _subscriptionCore.GetSubscriptionByUserId(userId);

                    userIds.Add(subscription.UserId);

                    if (subscription.SubscriptionTypeId == (int)Enums.SubscriptionTypes.Parent)
                    {
                        sharedTemplateIds = _templateCore.GetMasterSharedTemplateIds(subscription.SubscriptionId);
                        userIds.AddRange(_subscriptionCore.GetChildUserIdsByMasterId(subscription.SubscriptionId));
                    }

                    pollingSessionIdsToFetch.AddRange(_pollingCore.GetPollingSessionIdsByUserIds(userIds, pf.IsArchived));

                    List<int> filteredPollingSessionIds = new List<int>();
                    filteredPollingSessionIds.AddRange(_pollingCore.GetPollingSessionIdsByFilter(pollingSessionIdsToFetch, pf));

                    List<PollingData> pollingSessions = _pollingCore.GetPollingDataByIds(filteredPollingSessionIds);

                    //foreach (var pollingSession in pollingSessions)
                    //{
                    //    PollingDataGetViewModel pdgvm = new PollingDataGetViewModel();

                    //    pdgvm.PolledTemplateMetaData = new List<PolledTemplateGetMetaDataViewModel>();

                    //    if (pollingSession.PolledTemplateMetaData != null)
                    //    {
                    //        pdgvm.MetaDataString = string.Join(" | ", pollingSession.PolledTemplateMetaData.Select(ptm => ptm.MetaDataKey.ToUpper() + "=" +
                    //        ptm.MetaDataValue.ToUpper()).ToList());
                    //        pdgvm.MetaDataString = pdgvm.MetaDataString.Replace("PASS/FAIL with a grade".ToUpper(), "PASS/FAIL @ 80% with a grade".ToUpper());
                    //        pdgvm.MetaDataString = pdgvm.MetaDataString.Replace("PASS/FAIL with a grade 100".ToUpper(), "PASS/FAIL @ 100% with a grade".ToUpper());

                    //        pdgvm.MetaDataString += string.Join(" | ", pollingSession.Template.TemplateMetaData.Select(tm => tm.MetaDataKey.ToUpper() + "=" +
                    //        tm.MetaDataValue.ToUpper()).ToList());
                    //        pdgvm.MetaDataString = pdgvm.MetaDataString.Replace("PASS/FAIL with a grade".ToUpper(), "PASS/FAIL @ 80% with a grade".ToUpper());
                    //        pdgvm.MetaDataString = pdgvm.MetaDataString.Replace("PASS/FAIL with a grade 100".ToUpper(), "PASS/FAIL @ 100% with a grade".ToUpper());

                    //        foreach (var metaData in pollingSession.PolledTemplateMetaData)
                    //        {
                    //            PolledTemplateGetMetaDataViewModel ptgmdvm = new PolledTemplateGetMetaDataViewModel();
                    //            ptgmdvm = (PolledTemplateGetMetaDataViewModel)_utilityFunctions.MapFields(metaData, ptgmdvm);
                    //            pdgvm.PolledTemplateMetaData.Add(ptgmdvm);
                    //        }
                    //    }

                    //    pdgvm.PollingDataTags = new List<PollingDataTagGetViewModel>();

                    //    if (pollingSession.PollingDataTags != null)
                    //    {
                    //        foreach (var pollingDataTag in pollingSession.PollingDataTags)
                    //        {
                    //            PollingDataTagGetViewModel pdtgvm = new PollingDataTagGetViewModel();
                    //            pdtgvm = (PollingDataTagGetViewModel)_utilityFunctions.MapFields(pollingDataTag, pdtgvm);
                    //            pdtgvm.Name = pollingDataTag.Tag.Name;
                    //            pdgvm.PollingDataTags.Add(pdtgvm);
                    //        }
                    //    }

                    //    if (!string.IsNullOrWhiteSpace(subscription.SpecialName) &&
                    //        subscription.SpecialName.Equals(HersheyConstants.SPECIAL_NAME))
                    //        pdgvm.ShowSyncedStatus = true;

                    //    pdgvm.IsSynced = pollingSession.IsSynced;
                    //    pdgvm.PollingDataId = pollingSession.PollingDataId;
                    //    pdgvm.PollingStartDate = pollingSession.StartDate;
                    //    pdgvm.PollingEndDate = pollingSession.EndDate;
                    //    pdgvm.JoinCode = string.IsNullOrEmpty(pollingSession.JoinCode) ? subscription.AccessKey : pollingSession.JoinCode;
                    //    pdgvm.LastModifiedDate = pollingSession.LastModifiedDate;
                    //    pdgvm.TemplateId = pollingSession.TemplateId;
                    //    pdgvm.TemplateName = pollingSession.Template.TemplateName;
                    //    pdgvm.ImageUrl = pollingSession.Template.Slides.FirstOrDefault(s => s.SlideOrdinal == 1).URL;
                    //    pdgvm.IsTimeline = pollingSession.PolledSlides.Any(x => x.Slide.IsTimeline);
                    //    pdgvm.OperatorName = pollingSession.ApplicationUser.UserName;
                    //    pdgvm.PolledSlidesCount = pollingSession.PolledSlides.Count;

                    //    if (sharedTemplateIds.Contains(pollingSession.TemplateId))
                    //        pdgvm.IsAggregated = true;

                    //    lpdgvm.Add(pdgvm);
                    //}

                    //Parallel.ForEach(new ConcurrentBag<PollingDataGetViewModel>(lpdgvm), pollingSession =>
                    //{
                    //    CloudBlobBlockAccessUrlViewModel cloudBlobBlockAccessUrlViewModel = new CloudBlobBlockAccessUrlViewModel()
                    //    {
                    //        ImageUrl = pollingSession.ImageUrl,
                    //        RootDirectory = AzureConstants.ROOT_DIRECTORY_NAME,
                    //        UserId = userId,
                    //        SubDirectoryLevelOne = pollingSession.TemplateId.ToString(),
                    //        URLExpiryDate = DateTime.UtcNow.AddDays(3)
                    //    };
                    //    pollingSession.ImageUrl = "https://img.freepik.com/free-vector/simple-blue-gradient-background-vector-business_53876-143439.jpg";
                    //});
                }

                return _utilityFunctions.ReturnResponse(lpdgvm, ResponseType.SUCCESS, ResponseType.SUCCESS);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
