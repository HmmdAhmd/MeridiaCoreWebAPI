using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class UserPasswordPolicy
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ApplicationUser")]
        [Required]
        public string UserId { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
