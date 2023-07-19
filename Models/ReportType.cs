using System.ComponentModel.DataAnnotations;

namespace MeridiaCoreWebAPI.Models
{
    public class ReportType
    {
        [Key]
        public int ReportTypeId { get; set; }
        public string Name { get; set; }
    }
}
