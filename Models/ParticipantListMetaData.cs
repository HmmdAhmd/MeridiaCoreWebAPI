using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class ParticipantListMetaData
    {
        [Key]
        public int ParticipantListMetaDataId { get; set; }
        [ForeignKey("ParticipantList")]
        public int ParticipantListId { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }
        public string? CategoryColor { get; set; }
        [ForeignKey("GlobalListMetaData")]
        public int? GlobalListMetaDataId { get; set; }
        public virtual ParticipantList ParticipantList { get; set; }
        public virtual GlobalListMetaData GlobalListMetaData { get; set; }
    }
}
