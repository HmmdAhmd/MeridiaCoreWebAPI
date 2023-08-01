using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class MeridiaClientRecord
    {
        [Key]
        public int MeridiaClientRecordId { get; set; }
        public string? CompanyName { get; set; }        
        public string? Phone { get; set; }
        public string? Email { get; set; }                
        public string? RefferalCode { get; set; }        
        public int SubscriptionExpirationMonths { get; set; }
        [ForeignKey("Subscription")]
        public int? SubscriptionId { get; set; }
        [ForeignKey("SubscriptionPlan")]
        public int? SubscriptionPlanId { get; set; }
        public virtual SubscriptionPlan SubscriptionPlan { get; set; }
        public virtual Subscription Subscription { get; set; }
        public virtual ICollection<MeridiaSalesRecord> MeridiaSalesRecords { get; set; }
    }
}
