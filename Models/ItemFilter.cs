using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class ItemFilter
    {
        [Key]
        public int ItemFilterId { get; set; }
        [ForeignKey("DashboardItem")]
        [Required]
        public int DashboardItemId { get; set; }
        [ForeignKey("GlobalListMetaData")]
        public int GlobalListMetaDataId { get; set; }
        public string? Value { get; set; }
        public int Order { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public virtual DashboardItem DashboardItem { get; set; }
        public virtual GlobalListMetaData GlobalListMetaData { get; set; }
    }
}
