using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class PollingSessionModeratorRole
    {
        [ForeignKey("Moderator")]
        public int ModeratorId { get; set; }
        [ForeignKey("ModeratorRole")]
        public int ModeratorRoleId { get; set; }
        public virtual Moderator Moderator { get; set; }
        public virtual ModeratorRole ModeratorRole { get; set; }
    }
}
