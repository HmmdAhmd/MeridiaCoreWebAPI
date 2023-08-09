using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class RenewSubscriptionLink
    {
        [Key]
        public int RenewSubscriptionLinkId { get; set; }
        [ForeignKey("ApplicationUser")]
        [Required]
        public string UserId { get; set; }
        public string? Token { get; set; }
        public string? URL { get; set; }
        public bool IsActive { get; set; }
        public bool AutoRenewal { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModified { get; set; }
    }
}
