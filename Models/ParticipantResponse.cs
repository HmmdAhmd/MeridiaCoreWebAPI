using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class ParticipantResponse
    {
        [Key]
        public int ParticipantResponseId { get; set; }
        public int AnswerOrdinal { get; set; }
        public DateTime Date { get; set; }
        public string? KeypadId { get; set; }
        public string? ParticipantKey { get; set; }
        [ForeignKey("PolledSlide")]
        public int PolledSlideId { get; set; }
        [ForeignKey("PollingParticipant")]
        public int? PollingParticipantId { get; set; }
        public int Repeat { get; set; }
        public long VideoTime { get; set; }
        public string? FreeFormText { get; set; }
        public virtual PolledSlide PolledSlide { get; set; }
        public virtual PollingParticipant PollingParticipant { get; set; }
        [NotMapped]
        public double WeightedResponse { get; set; }
    }
}
