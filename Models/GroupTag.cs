using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class GroupTag
    {
        [Key]
        public int GroupTagId { get; set; }
        [ForeignKey("Tag")]
        public int TagId { get; set; }
        [ForeignKey("ParticipantList")]
        public int ParticipantListId { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual Tag Tag { get; set; }
        public virtual ParticipantList ParticipantList { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
