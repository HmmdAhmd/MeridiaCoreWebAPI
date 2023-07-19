using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class TemplateTag
    {
        [Key]
        public int TemplateTagId { get; set; }
        [ForeignKey("Tag")]
        public int TagId { get; set; }
        [ForeignKey("Template")]
        public int TemplateId { get; set; }
        public int CreatedById { get; set; }
        public virtual Tag Tag { get; set; }
        public virtual Template Template { get; set; }
    }
}
