using System.ComponentModel.DataAnnotations;

namespace MeridiaCoreWebAPI.Models
{
    public class EZVoteConnectBuild
    {
        [Key]
        public int EZVoteConnectBuildId { get; set; }
        [Required]
        public string BuildNumber { get; set; }
        public string? ReleaseNotes { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}
