using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class ParticipantList
    {
        [Key]
        public int ParticipantListId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int NoOfResponsesPerSlide { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsArchived { get; set; }
        [ForeignKey("ParticipantList")]
        public int? ParentParticipantListId { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public virtual ICollection<ParticipantListData> ParticipantListData { get; set; }
        public virtual ICollection<GroupTag> GroupTag { get; set; }
        public virtual ICollection<GroupParticipantAssociation> GroupParticipants { get; set; }
        public virtual ICollection<SharedParticipantGroup> SharedParticipantGroups { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ParticipantList ParentParticipantList { get; set; }
    }
}
