using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        public string? Name { get; set; }
        [ForeignKey("Subscription")]
        public int SubscriptionId { get; set; }
        public bool IsSystemGenerated { get; set; }
        public virtual Subscription Subscription { get; set; }
    }
}
