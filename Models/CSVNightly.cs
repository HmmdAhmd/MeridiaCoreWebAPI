using System.ComponentModel.DataAnnotations;

namespace MeridiaCoreWebAPI.Models
{
    public class CSVNightly
    {
        [Key]
        public int CSVNightlyId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string CSVContent { get; set; }
        public string PollingDataIds { get; set; }
        public string Status { get; set; }
    }
}
