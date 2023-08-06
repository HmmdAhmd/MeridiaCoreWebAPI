using MeridiaCoreWebAPI.Data;
using MeridiaCoreWebAPI.Models;
using MeridiaCoreWebAPI.Utility;
using static MeridiaCoreWebAPI.Utility.Enums;
using Microsoft.EntityFrameworkCore;
using MeridiaCoreWebAPI.ViewModels;

namespace MeridiaCoreWebAPI.Core
{
    public class TemplateCore
    {
        private ApplicationDbContext _db;

        public TemplateCore(ApplicationDbContext db) => _db = db;

        public List<int> GetSharedTemplateIds(int subscriptionId, int parentId)
        {
            try
            {
                List<int> parentIds = _db.Subscription.Where(s => s.ParentId == parentId && s.Status == (short)SubscriptionStateEnum.Active)
                    .Select(x => x.SubscriptionId).ToList();

                parentIds.Add(parentId);

                return _db.SharedTemplate.Where(st => st.ChildSubscriptionId == subscriptionId && parentIds.Contains(st.ParentId))
                    .Select(st => st.TemplateId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Template> GetTemplatesInfoByIds(List<int> templateIds)
        {
            try
            {
                return _db.Template.Where(t => templateIds.Contains(t.TemplateId))
                    .Include(t => t.Slides)
                    .Include(t => t.TemplateMetaData)
                    .Include(t => t.TemplateTags).ThenInclude(tt => tt.Tag)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<int> GetTemplateIdsByUserIds(List<string> userIds, bool isArchived)
        {
            try
            {
                return _db.Template.Where(t => userIds.Contains(t.UserId) && !t.IsDeleted && t.IsArchived == isArchived).Select(t => t.TemplateId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<int> GetTemplatesIdsByIdsFilter(List<int> templateIdsToFetch, Filter tf)
        {
            List<int> templateIds = new List<int>();

            var query = _db.Template.Where(t => templateIdsToFetch.Contains(t.TemplateId) && !t.IsDeleted && t.IsArchived == tf.IsArchived);

            if (tf.TagsSearched.Count > 0)
                query = query.Where(t => t.TemplateTags.Any(tt => tf.TagsSearched.Contains(tt.Tag.Name)));

            switch (tf.OrderByColumn)
            {
                case FilterColumn.CREATED_DATE:
                    if (tf.OrderByType == ColumnOrder.DESCENDING)
                        templateIds = query.OrderByDescending(t => t.CreatedDate).Skip(tf.SkipRecords).Take(tf.PageSize)
                            .Select(t => t.TemplateId).ToList();
                    else
                        templateIds = query.OrderBy(t => t.CreatedDate).Skip(tf.SkipRecords).Take(tf.PageSize).Select(t => t.TemplateId).ToList();
                    break;
                case FilterColumn.TEMPLATE_NAME:
                    if (tf.OrderByType == ColumnOrder.DESCENDING)
                        templateIds = query.OrderByDescending(t => t.TemplateName).Skip(tf.SkipRecords).Take(tf.PageSize)
                            .Select(t => t.TemplateId).ToList();
                    else
                        templateIds = query.OrderBy(t => t.TemplateName).Skip(tf.SkipRecords).Take(tf.PageSize).Select(t => t.TemplateId).ToList();
                    break;
                default:
                    break;
            }

            return templateIds;
        }

        public List<int> GetMasterSharedTemplateIds(int masterId)
        {
            try
            {
                return _db.SharedTemplate.Where(st => st.ParentId == masterId).GroupBy(st => st.TemplateId).Select(st => st.Key).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Slide> GetSlidesByTemplateIds(List<int> templateIds)
        {
            try
            {
                return _db.Slide.Where(s => templateIds.Contains(s.TemplateId)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
