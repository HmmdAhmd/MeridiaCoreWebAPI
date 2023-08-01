using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class Slide
    {
        [Key]
        public int SlideId { get; set; }
        public string? URL { get; set; }
        public string? VideoURL { get; set; }
        public int SlideOrdinal { get; set; }
        public string? SlideType { get; set; }
        public int FilterSlideOrdinal { get; set; }
        public int FilteredSlideOrdinal { get; set; }
        public int FilterAnswerOrdinal { get; set; }
        public int CompareSlide1Ordinal { get; set; }
        public int CompareSlide2Ordinal { get; set; }
        public int ResponseSourceSlideOrdinal { get; set; }
        public string? TeamAssignmentType { get; set; }
        public int ScoringDecimalPlaces { get; set; }
        public int TeamQuestionOrdinal { get; set; }
        public string? ScoringType { get; set; }
        public string? MasterSlideKey { get; set; }
        public string? MediaAssetKey { get; set; }
        public int PollingDisposition { get; set; }
        public int ResponseCollection { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsMultiVote { get; set; }
        public bool IsMustVote { get; set; }
        public bool IsTimeline { get; set; }
        public bool IsVideoSlide { get; set; }
        public int MaxParticipantResponse { get; set; }
        public string? MaxParticipantResponseType { get; set; }
        public bool AllowRepeatSelection { get; set; }
        public DateTime LastModifiedDate { get; set; }
        [ForeignKey("Template")]
        public int TemplateId { get; set; }
        public bool IsConditionalBranching { get; set; }
        public bool IsFreeForm { get; set; }
        public bool IsResponseRequired { get; set; }
        public virtual Template Template { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        [NotMapped]
        public string ImageBase64 { get; set; }
        [NotMapped]
        public string ImageType { get; set; }
        [NotMapped]
        public string VideoBase64 { get; set; }
        [NotMapped]
        public string VideoType { get; set; }
        [NotMapped]
        public string FileId { get; set; }
        public bool IsVisible { get; set; }
    }
}
