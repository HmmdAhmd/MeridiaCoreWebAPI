using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class TemplateMetaData
    {
        [Key]
        public int TemplateMetaDataId { get; set; }
        public string? MetaDataKey { get; set; }
        public string? MetaDataValue { get; set; }
        public bool IsRequired { get; set; }
        public int ValueType { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime LastModifiedDate { get; set; }
        [ForeignKey("Template")]
        public int TemplateId { get; set; }
        public virtual Template Template { get; set; }
    }
}
