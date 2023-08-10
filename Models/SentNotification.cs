using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class SentNotification
    {
        [Key]
        public int SentNotificationId { get; set; }
        [ForeignKey("NotificationSubscriptionAssociation")]
        [Required]
        public int NotificationSubscriptionAssociationId { get; set; }
        public int DismissCount { get; set; }
        public bool HasActionTaken { get; set; }
        public string? DeviceUUId { get; set; }
        public virtual NotificationSubscriptionAssociation NotificationSubscriptionAssociation { get; set; }
    }
}
