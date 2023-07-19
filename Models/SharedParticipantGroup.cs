using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class SharedParticipantGroup
    {
        [Key]
        public int SharedParticipantGroupId { get; set; }
        [ForeignKey("ParticipantList")]
        public int ParticipantListId { get; set; }
        public DateTime AssociationDate { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public string ParentUserId { get; set; }
        public virtual ParticipantList ParticipantList { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
