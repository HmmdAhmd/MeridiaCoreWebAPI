using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class SyncedData
    {
        [Key]
        public int SyncedDataId { get; set; }
        [ForeignKey("Subscription")]
        public int SubscriptionId { get; set; }
        public int EntityId { get; set; }
        public DateTime SyncedDate { get; set; }
        public string EntityType { get; set; }
        public virtual Subscription Subscription { get; set; }
    }
}
