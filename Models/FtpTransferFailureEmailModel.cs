namespace MeridiaCoreWebAPI.Models
{
    public class FtpTransferFailureEmailModel
    {
        public string ErrorMessage { get; set; }
        public DateTime TransferFromDate { get; set; }
        public DateTime TransferToDate { get; set; }
        public int CsvNightlyReferenceId { get; set; }
        public string Environment { get; set; }        
    }
}
