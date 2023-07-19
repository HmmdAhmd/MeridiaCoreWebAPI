namespace MeridiaCoreWebAPI.Models
{
    public class Playlist
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdationDate { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }
        public virtual ApplicationUser UpdatedBy { get; set; }
        public bool IsDeleted{ get; set; }
    }
}
