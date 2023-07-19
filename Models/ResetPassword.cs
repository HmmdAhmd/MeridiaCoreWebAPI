namespace MeridiaCoreWebAPI.Models
{
    public class ResetPassword
    {
        public int ResetPasswordId { get; set; }
        public string UserId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
        public string ResetToken { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
