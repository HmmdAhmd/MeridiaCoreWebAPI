using System.ComponentModel.DataAnnotations;

namespace MeridiaCoreWebAPI.Models
{
    public class Setting
    {
        [Key]
        public int SettingId { get; set; }
        public string? Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
