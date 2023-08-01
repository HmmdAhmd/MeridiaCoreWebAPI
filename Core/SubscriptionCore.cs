using MeridiaCoreWebAPI.Data;
using MeridiaCoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using static MeridiaCoreWebAPI.Utility.Enums;

namespace MeridiaCoreWebAPI.Core
{
    public class SubscriptionCore
    {
        private readonly ApplicationDbContext _db;

        public SubscriptionCore(ApplicationDbContext db) => _db = db;

        public Subscription GetSubscriptionByUserId(string id)
        {
            try
            {
                return _db.Subscription.Include(s => s.ApplicationUser).SingleOrDefault(s => s.UserId == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> GetChildUserIdsByMasterId(int masterId)
        {
            try
            {
                return _db.Subscription.Where(s => s.ParentId == masterId && s.Status == (short)SubscriptionStateEnum.Active)
                    .Include(s => s.ApplicationUser).Select(s => s.ApplicationUser.Id).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Subscription> GetChildSubscriptionsByMasterId(int id)
        {
            try
            {
                return _db.Subscription.Include(s => s.ApplicationUser).Where(s => s.ParentId == id && s.Status == (short)SubscriptionStateEnum.Active)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
