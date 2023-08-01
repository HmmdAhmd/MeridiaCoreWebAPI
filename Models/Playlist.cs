using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class Playlist
    {
        [Key]
        public int Id{ get; set; }
        [ForeignKey("ApplicationUser")]
        public int? CreatedById { get; set; }
        [ForeignKey("ApplicationUser")]
        public int? UpdatedById { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdationDate { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }
        public virtual ApplicationUser UpdatedBy { get; set; }
        public bool IsDeleted{ get; set; }
    }
}
