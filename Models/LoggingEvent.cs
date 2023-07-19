using System.ComponentModel.DataAnnotations;

namespace MeridiaCoreWebAPI.Models
{
    public class LoggingEvent
    {
        [Key]        
        public int LoggingEventId { get; set; }
        [Required]
        public string LoggingEventName { get; set; }
    }
}
