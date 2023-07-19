using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class VideoFilter
    {
        [Key]
        public int VideoFilterId { get; set; }
        [ForeignKey("PolledSlide")]
        public int PolledSlideId { get; set; }
        public virtual PolledSlide PolledSlide { get; set; }
    }
}
