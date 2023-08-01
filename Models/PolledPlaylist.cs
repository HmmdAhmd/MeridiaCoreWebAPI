using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class PolledPlaylist
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Playlist")]
        public int? PlaylistId { get; set; }
        public virtual Playlist Playlist { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate{ get; set; }
    }
}
