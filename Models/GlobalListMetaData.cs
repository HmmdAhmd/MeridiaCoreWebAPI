using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class GlobalListMetaData
    {
        [Key]
        public int GlobalListMetaDataId { get; set; }
        public string Key { get; set; }
        public int Order { get; set; }
        public string AnswerFormat { get; set; }
        public bool IsVisible { get; set; }
        public bool IsOperatorVisible { get; set; }
        public bool IsIdentifyingColumn { get; set; }
        [ForeignKey("ParticipantList")]
        public int ParticipantListId { get; set; }
        public virtual ParticipantList ParticipantList { get; set; }
    }
}
