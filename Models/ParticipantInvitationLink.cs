using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class ParticipantInvitationLink
    {
        [Key]
        public int ParticipantInvitationLinkId { get; set; }
        [ForeignKey("Template")]
        public int TemplateId { get; set; }
        [ForeignKey("ParticipantListId")]
        public int ParticipantListId { get; set; }
        [ForeignKey("ParticipantInvitationLogId")]
        public int ParticipantInvitationLogId { get; set; }
        public string? ParticipantUniqueId { get; set; }
        [Required(AllowEmptyStrings =true)]
        public string InvitationCode { get; set; }
        public bool IsExpired { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModified { get; set; }
        public virtual Template Template { get; set; }
        public virtual ParticipantList ParticipantList { get; set; }
        public virtual ParticipantInvitationLog ParticipantInvitationLog { get; set; }
    }
}
