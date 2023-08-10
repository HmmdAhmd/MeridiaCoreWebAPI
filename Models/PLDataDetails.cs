using System.ComponentModel.DataAnnotations;

namespace MeridiaCoreWebAPI.Models
{
    public class PLDataDetails
    {
        [Key]
        public int PLDataDetailsId { get; set; }
        public string? ParticipantUniqueId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModified { get; set; }
    }
}
