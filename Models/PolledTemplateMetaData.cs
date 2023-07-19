using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class PolledTemplateMetaData
    {
        [Key]
        public int PolledTemplateMetaDataId { get; set; }
        public string MetaDataKey { get; set; }
        public string MetaDataValue { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsRequired { get; set; }
        public int ValueType { get; set; }
        [ForeignKey("PollingData")]
        public int PollingDataId { get; set; }
        public virtual PollingData PollingData { get; set; }
    }
}
