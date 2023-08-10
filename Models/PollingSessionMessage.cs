using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class PollingSessionMessage
    {
        [Key]
        public int PollingSessionMessageId { get; set; }
        public string? Text { get; set; }
        [ForeignKey("PollingData")]
        public int PollingDataId { get; set; }
        public DateTime Date { get; set; }
        public virtual PollingData PollingData { get; set; }
    }
}
