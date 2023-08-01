using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class NotificationSubscriptionAssociation
    {
        [Key]
        public int NotificationSubscriptionAssociationId { get; set; }
        [ForeignKey("Notification")]
        [Required]
        public int NotificationId { get; set; }
        [ForeignKey("ApplicationUser")]        
        public string? UserId { get; set; }
        [ForeignKey("NotificationObserverType")]
        [Required]
        public int NotificationObserverTypeId { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Notification Notification { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual NotificationObserverType NotificationObserverType { get; set; }
    }
}
