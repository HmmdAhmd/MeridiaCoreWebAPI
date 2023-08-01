using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class Moderator
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ApplicationUser")]
        public string? UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsArchived { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual List<PollingSessionModeratorRole> PollingSessionModeratorRoles { get; set; }
    }
}
