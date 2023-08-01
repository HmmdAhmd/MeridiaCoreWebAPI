using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class DashboardItem
    {
        [Key]
        public int DashboardItemId { get; set; }
        [ForeignKey("Subscription")]
        [Required]
        public int SubscriptionId { get; set; }
        public string? Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int SortingColumn { get; set; }
        public string? SortingColumnType { get; set; }
        public int SortingPattern { get; set; }
        public string? DateType { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? RollingDate { get; set; }
        public virtual Subscription Subscription { get; set; }
        public virtual ICollection<ItemFilter> ItemFilter { get; set; }
    }
}
