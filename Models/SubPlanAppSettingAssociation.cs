using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class SubPlanAppSettingAssociation
    {
        [Key]
        public int SubPlanAppSettingAssociationId { get; set; }
        [ForeignKey("SubscriptionPlan")]
        public int SubscriptionPlanId { get; set; }
        [ForeignKey("AppSetting")]
        public int AppSettingId { get; set; }
        public string? Value { get; set; }
        public virtual SubscriptionPlan SubscriptionPlan { get; set; }
        public virtual AppSetting AppSetting { get; set; }
    }
}
