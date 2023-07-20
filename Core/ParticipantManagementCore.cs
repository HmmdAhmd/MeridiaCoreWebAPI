using MeridiaCoreWebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace MeridiaCoreWebAPI.Core
{
    public class ParticipantManagementCore
    {
        private ApplicationDbContext _db;
        public ParticipantManagementCore(ApplicationDbContext db) => _db = db;

        public List<string> GetParticipantGroupNamesByTemplateId(int templateId, string userId)
        {
            try
            {
                return _db.GroupTemplateAssociation.Where(gta => gta.TemplateId == templateId && gta.UserId.Equals(userId) &&
                !gta.ParticipantList.IsArchived && !gta.ParticipantList.IsDeleted)
                    .Include(gta => gta.ParticipantList)
                    .Select(gta => gta.ParticipantList.Name).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
