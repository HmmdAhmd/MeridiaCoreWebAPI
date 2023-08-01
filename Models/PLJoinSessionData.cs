using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class PLJoinSessionData
    {
        [Key]
        public int PLJoinSessionDataId { get; set; }
        [ForeignKey("ParticipantListData")]
        public int ParticipantListDataId { get; set; }
        [ForeignKey("PollingParticipant")]
        public int PollingParticipantId { get; set; }
        public string? Value { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ParticipantListData ParticipantListData { get; set; }
        public virtual PollingParticipant PollingParticipant { get; set; }
    }
}
