using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class UserPasswordHistory
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ApplicationUser")]
        [Required]
        public string UserId { get; set; }
        public string? PasswordHash { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
