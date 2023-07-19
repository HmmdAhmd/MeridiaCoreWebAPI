using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class PollingDataTag
    {
        [Key]
        public int PollingDataTagId { get; set; }
        [ForeignKey("PollingData")]
        public int PollingDataId { get; set; }
        [ForeignKey("Tag")]
        public int TagId { get; set; }
        [ForeignKey("Subscription")]
        public int? CreatedById { get; set; }
        public virtual PollingData PollingData { get; set; }
        public virtual Tag Tag { get; set; }
        public virtual Subscription Subscription { get; set; }
    }
}
