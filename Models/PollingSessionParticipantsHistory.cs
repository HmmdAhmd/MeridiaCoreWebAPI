using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class PollingSessionParticipantsHistory
    {
        [Key]
        public int PollingSessionParticipantsHistoryId { get; set; }
        [ForeignKey("PollingData")]
        public int PollingDataId { get; set; }
        public string CompressedParticipantUniqueIds { get; set; }
        public virtual PollingData PollingData { get; set; }
    }
}
