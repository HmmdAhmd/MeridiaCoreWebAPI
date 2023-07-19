using System.ComponentModel.DataAnnotations;

namespace MeridiaCoreWebAPI.Models
{
    public class LogEventLevel
    {
        [Key]        
        public int LogEventLevelId { get; set; }
        [Required]
        public string LogEventLevelName { get; set; }
    }
}
