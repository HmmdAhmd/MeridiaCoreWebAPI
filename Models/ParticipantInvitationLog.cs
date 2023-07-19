using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class ParticipantInvitationLog
    {
        [Key]
        public int ParticipantInvitationLogId { get; set; }
        [ForeignKey("Template")]
        public int TemplateId { get; set; }
        [ForeignKey("ParticipantListId")]
        public int ParticipantListId { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public int Status { get; set; }
        public string StatusDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModified { get; set; }
        public virtual Template Template { get; set; }
        public virtual ParticipantList ParticipantList { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<ParticipantInvitationLink> ParticipantInvitationLinks { get; set; }
    }
}
