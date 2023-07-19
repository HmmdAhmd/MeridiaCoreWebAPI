using System.ComponentModel.DataAnnotations;

namespace MeridiaCoreWebAPI.Models
{
    public class AppSettingValueType
    {
        [Key]
        public int AppSettingValueTypeId { get; set; }
        public string Title { get; set; }          
    }
}
