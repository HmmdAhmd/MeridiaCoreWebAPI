using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Message { get; set; }
        [ForeignKey("ActionType")]
        [Required]
        public int ActionTypeId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsCritical { get; set; }
        public int DismissCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool EnableDateRange { get; set; }
        [Column(TypeName = "Date")]
        public DateTime NotificationFromDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime NotificationToDate { get; set; }
        public virtual ICollection<NotificationSubscriptionAssociation> NotificationSubscriptionAssociations { get; set; }
        public virtual ActionType ActionType { get; set; }
        public virtual ICollection<NotificationMetaData> NotificationsMetaData { get; set; }
    }
}
