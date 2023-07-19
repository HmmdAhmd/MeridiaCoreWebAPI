using System.ComponentModel.DataAnnotations;

namespace MeridiaCoreWebAPI.Models
{
    public class ActivityLogs
    {
        [Key]
        public int LogId { get; set; }
        public string MessageTemplate { get; set; }
        public string Level { get; set; }
        public string Exception { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Message { get; set; }
        public string Properties { get; set; }
    }
}
