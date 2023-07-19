using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class SubscriptionTemplateSetting
    {
        [Key]
        public int SubscriptionTemplateSettingId { get; set; }
        [Required]
        [ForeignKey("TemplateSetting")]
        public int TemplateSettingId { get; set; }
        [Required]
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual TemplateSetting TemplateSetting { get; set; }
    }
}
