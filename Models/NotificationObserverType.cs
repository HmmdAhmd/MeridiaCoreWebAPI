using System.ComponentModel.DataAnnotations;

namespace MeridiaCoreWebAPI.Models
{
    public class NotificationObserverType
    {
        [Key]
        public int NotificationObserverTypeId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
