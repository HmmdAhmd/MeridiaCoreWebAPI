using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class PollingSessionModeratorRole
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Moderator")]
        public int ModeratorId { get; set; }
        [Column(Order = 2)]
        [ForeignKey("ModeratorRole")]
        public int ModeratorRoleId { get; set; }
        public virtual Moderator Moderator { get; set; }
        public virtual ModeratorRole ModeratorRole { get; set; }
    }
}
