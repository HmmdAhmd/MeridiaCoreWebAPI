using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class GroupTemplateAssociation
    {
        [Key]
        public int GroupTemplateAssociationId { get; set; }
        [ForeignKey("Template")]
        public int TemplateId { get; set; }
        [ForeignKey("ParticipantList")]
        public int ParticipantListId { get; set; }
        public DateTime AssociationDate { get; set; }
        [ForeignKey("ApplicationUser")]
        public string? UserId { get; set; }
        public virtual Template Template { get; set; }
        public virtual ParticipantList ParticipantList { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
