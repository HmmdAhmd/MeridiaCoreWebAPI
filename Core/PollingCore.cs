using MeridiaCoreWebAPI.Data;
using MeridiaCoreWebAPI.Models;
using MeridiaCoreWebAPI.Utility;
using MeridiaCoreWebAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MeridiaCoreWebAPI.Core
{
    public class PollingCore
    {
        private ApplicationDbContext _db;

        public PollingCore(ApplicationDbContext db) => _db = db;

        public List<int> GetPollingSessionIdsByUserIds(List<string> userIds, bool isArchived)
        {
            try
            {
                return _db.PollingData.Where(pd => userIds.Contains(pd.UserId) && !pd.IsDeleted && pd.IsArchived == isArchived)
                    .Select(pd => pd.PollingDataId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<int> GetPollingSessionIdsByFilter(List<int> pollingSessionIdsToFetch, Filter pf)
        {
            List<int> pollingSessionIds = new List<int>();

            var query = _db.PollingData.Where(pd => pollingSessionIdsToFetch.Contains(pd.PollingDataId) && !pd.IsDeleted &&
            pd.IsArchived == pf.IsArchived && pd.PolledSlides.Any(ps => ps.PollAnswerCount > 0));

            if (pf.TagsSearched.Count > 0)
                query = query.Where(pd => pd.PollingDataTags.Any(pdt => pf.TagsSearched.Contains(pdt.Tag.Name)));

            switch (pf.OrderByColumn)
            {
                case FilterColumn.STARTED_DATE:
                    if (pf.OrderByType == "DESC")
                        pollingSessionIds =  query.OrderByDescending(pd => pd.StartDate).Skip(pf.SkipRecords).Take(pf.PageSize)
                            .Select(pd => pd.PollingDataId).ToList();
                    else
                        pollingSessionIds = query.OrderBy(pd => pd.StartDate).Skip(pf.SkipRecords).Take(pf.PageSize)
                            .Select(pd => pd.PollingDataId).ToList();
                    break;
                case FilterColumn.TEMPLATE_NAME:
                    if (pf.OrderByType == "DESC")
                        pollingSessionIds = query.OrderByDescending(pd => pd.Template.TemplateName).Skip(pf.SkipRecords).Take(pf.PageSize)
                            .Select(pd => pd.PollingDataId).ToList();
                    else
                        pollingSessionIds = query.OrderBy(pd => pd.Template.TemplateName).Skip(pf.SkipRecords).Take(pf.PageSize)
                            .Select(pd => pd.PollingDataId).ToList();
                    break;
                default:
                    break;
            }

            return pollingSessionIds;
        }

        public List<PollingData> GetPollingDataByIds(List<int> ids)
        {
            try
            {
                return _db.PollingData
                    .Include(pd => pd.ApplicationUser)
                    .Include(pd => pd.PolledTemplateMetaData)
                    .Include(pd => pd.PollingDataTags).ThenInclude(pd => pd.Tag)
                    .Include(pd => pd.Template)
                    .ThenInclude(pd => pd.Slides)
                    .Include(pd => pd.Template.TemplateMetaData)
                    .Include(pd => pd.PolledSlides).ThenInclude(pd => pd.Slide)
                    .Where(pd => ids.Contains(pd.PollingDataId))
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
