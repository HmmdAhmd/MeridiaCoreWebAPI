namespace MeridiaCoreWebAPI.Models
{
    public class PolledPlaylist
    {
        public int Id { get; set; }
        public Playlist  Playlist{ get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate{ get; set; }
    }
}
