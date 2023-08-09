using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class MeridiaSalesRecord
    {
        public int MeridiaSalesRecordId { get; set; }        
        public string? PurchasePointOfContact { get; set; }        
        public string? PO { get; set; }
        public DateTime ShipDate { get; set; }
        public string? ShipLocation { get; set; }        
        public string? NumberOfKeypads { get; set; }
        public string? KeypadType { get; set; }
        public string? KeypadNumberSequence { get; set; }
        public string? BaseId { get; set; }
        public string? MatchMode { get; set; }
        public string? NumberOfBases { get; set; }
        public string? BaseType { get; set; }                        
        public bool Status { get; set; }
        public int SubscriptionExpirationMonths { get; set; } // TODO: Remove field ?
        [ForeignKey("MeridiaClientRecord")]
        public int? MeridiaClientRecordId { get; set; }
        public virtual MeridiaClientRecord MeridiaClientRecord { get; set; }
    }
}
