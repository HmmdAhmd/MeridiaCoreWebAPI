using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class SubscriptionSetting
    {
        [Key]
        public int SubscriptionSettingId { get; set; }
        [ForeignKey("Subscription")]
        public int SubscriptionId { get; set; }
        [ForeignKey("Setting")]
        public int SettingId { get; set; }
        public string Value { get; set; }
        public virtual Setting Setting { get; set; }
        public virtual Subscription Subscription { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
