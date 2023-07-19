using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class SubscriptionAppSettingAssociation
    {
        [Key]
        public int SubscriptionAppSettingAssociationId { get; set; }        
        [ForeignKey("AppSetting")]
        public int AppSettingId { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public string Value { get; set; }
        public virtual AppSetting AppSetting { get; set; }        
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
