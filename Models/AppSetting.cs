using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class AppSetting
    {
        [Key]
        public int AppSettingId { get; set; }
        public string? Title { get; set; }
        [ForeignKey("AppSettingValueType")]
        public int AppSettingValueTypeId { get; set; }
        public virtual AppSettingValueType AppSettingValueType { get; set; }
    }
}
