using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }
        public string URL { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        [ForeignKey("ApplicationUser")]
        [Required]
        public string UserId { get; set; }
        [ForeignKey("PollingData")]
        [Required]
        public int PollingDataId { get; set; }
        [ForeignKey("ReportType")]
        public int ReportTypeId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual PollingData PollingData { get; set; }
        public virtual ReportType ReportType { get; set; }
    }
}
