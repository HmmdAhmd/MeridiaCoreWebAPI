using System.ComponentModel.DataAnnotations;

namespace MeridiaCoreWebAPI.Models
{
    public class AppSettingState
    {
        [Key]
        public int AppSettingStateId { get; set; }
        public string? Title { get; set; }          
    }
}
