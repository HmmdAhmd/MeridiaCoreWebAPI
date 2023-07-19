using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class NotificationMetaData
    {
        [Key]
        public int NotificationMetaDataId { get; set; }
        [Required]
        public string MetaDataKey { get; set; }
        [Required]
        public string MetaDataValue { get; set; }
        [ForeignKey("Notification")]
        [Required]
        public int NotificationId { get; set; }        
        public virtual Notification Notification { get; set; }
    }
}
