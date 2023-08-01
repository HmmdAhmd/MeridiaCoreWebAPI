using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class PolledSlide
    {
        [Key]
        public int PolledSlideId { get; set; }
        [ForeignKey("PollingData")]
        public int PollingDataId { get; set; }
        [ForeignKey("Slide")]
        public int SlideId { get; set; }
        public int PollOrdinal { get; set; }
        public int PollAnswerCount { get; set; }
        public string? PolledState { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaxParticipantResponse { get; set; }
        public string? MaxParticipantResponseType { get; set; }
        public bool AllowRepeatSelection { get; set; }
        public bool ExcludeFromReport { get; set; }
        public virtual Slide Slide { get; set; }
        public virtual PollingData PollingData { get; set; }
        public virtual ICollection<ParticipantResponse> ParticipantsResponse { get; set; }
        public virtual ICollection<PolledSlideImage> PolledSlideImages { get; set; }
        public virtual ICollection<VideoFilter> VideoFilters { get; set; }
    }
}
