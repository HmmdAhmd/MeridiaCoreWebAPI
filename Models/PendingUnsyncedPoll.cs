using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class PendingUnsyncedPoll
    {
        [Key]
        public int PendingUnsyncedPollsId { get; set; }                        
        [ForeignKey("PollingData")]
        public int PollingDataId { get; set; }
        public bool IsSynced { get; set; }
        public virtual PollingData PollingData { get; set; }
    }
}
