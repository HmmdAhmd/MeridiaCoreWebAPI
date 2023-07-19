using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class SharedTemplate
    {
        [Key]
        public int SharedTemplateId { get; set; }
        [ForeignKey("Template")]
        public int TemplateId { get; set; }
        public int ChildSubscriptionId { get; set; }
        public int ParentId { get; set; }
        public virtual Template Template { get; set; }
    }
}
