namespace MeridiaCoreWebAPI.Models
{
    public class PlaylistTemplates
    {
        public int Id { get; set; }
        public virtual Template Template { get; set; }
        public int Order { get; set; }
        public virtual Playlist Playlist{ get; set; }
        public DateTime AddedOn{ get; set; }
        public virtual ApplicationUser AddedBy { get; set; }
    }
}
