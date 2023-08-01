using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class PollingData
    {
        [Key]
        public int PollingDataId { get; set; }
        [ForeignKey("Template")]
        public int TemplateId { get; set; }
        [ForeignKey("ApplicationUser")]
        public string? UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsArchived { get; set; }
        public bool IsDeleted { get; set; }
        public string? PollingMode { get; set; }
        public int PollingState { get; set; }
        public string? PollingToken { get; set; }
        public bool IsSynced { get; set; }
        public string? JoinCode { get; set; }
        public int? ParticipantListId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Template Template { get; set; }
        public virtual ICollection<PollingSessionMessage> PollingSessionMessages { get; set; }
        public virtual ICollection<PolledSlide> PolledSlides { get; set; }
        public virtual ICollection<PollingParticipant> PollingParticipants { get; set; }
        public virtual ICollection<PolledTemplateMetaData> PolledTemplateMetaData { get; set; }
        public virtual ICollection<PollingDataTag> PollingDataTags { get; set; }
        public virtual PolledPlaylist PolledPlaylist { get; set; }
    }
}
