using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class PollingParticipant
    {
        public int PollingParticipantId { get; set; }
        [ForeignKey("PollingData")]
        public int PollingDataId { get; set; }
        public string ParticipantKey { get; set; }
        public string ParticipantName { get; set; }
        public string UniqueId { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsLatecomer { get; set; }
        public string ParticipantUniqueId { get; set; }
        public virtual PollingData PollingData { get; set; }        
    }
}
