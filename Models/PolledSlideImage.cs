using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class PolledSlideImage
    {
        [Key]
        public int PolledSlideImageId { get; set; }
        [ForeignKey("PolledSlide")]
        public int PolledSlideId { get; set; }
        public string? ImageURL { get; set; }
        public int ImageOrdinal { get; set; }
        public virtual PolledSlide PolledSlide { get; set; }
        [NotMapped]
        public string ImageBase64 { get; set; }
        [NotMapped]
        public string ImageType { get; set; }
    }
}
