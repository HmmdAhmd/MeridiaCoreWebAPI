namespace MeridiaCoreWebAPI.Models
{
    public class VideoFilter
    {
        public int VideoFilterId { get; set; }
        public int PolledSlideId { get; set; }
        public virtual PolledSlide PolledSlide { get; set; }
    }
}
