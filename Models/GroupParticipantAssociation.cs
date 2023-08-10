using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class GroupParticipantAssociation
    {
        [Key]
        public int GroupParticipantAssociationId { get; set; }
        [ForeignKey("ParticipantList")]
        public int ParticipantListId { get; set; }
        public string? ParticipantUniqueId { get; set; }
        public DateTime AssociationDate { get; set; }        
        public virtual ParticipantList ParticipantList { get; set; }                
    }
}
