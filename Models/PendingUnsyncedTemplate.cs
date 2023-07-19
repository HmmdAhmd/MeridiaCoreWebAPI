using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class PendingUnsyncedTemplate
    {
        [Key]
        public int PendingUnsyncedTemplateId { get; set; }                        
        [ForeignKey("Template")]
        public int TemplateId { get; set; }
        public bool IsSynced { get; set; }
        public virtual Template Template { get; set; }
    }
}
