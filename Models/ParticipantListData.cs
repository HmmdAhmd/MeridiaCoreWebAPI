using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class ParticipantListData
    {
        [Key]
        public int ParticipantListDataId { get; set; }
        [ForeignKey("ParticipantList")]
        public int ParticipantListId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string ParticipantUniqueId { get; set; }
        public bool IsVisible { get; set; }
        public bool IsRequired { get; set; }
        public bool IsOperatorVisible{ get; set; }
        public double WeightedResponse { get; set; }
        public bool MustBeUnique { get; set; }
        public string AnswerFormat { get; set; }
        public bool IsArchived { get; set; }
        [ForeignKey("GlobalListMetaData")]
        public int? GlobalListMetaDataId { get; set; }
        public virtual ParticipantList ParticipantList { get; set; }
        public virtual GlobalListMetaData GlobalListMetaData { get; set; }
    }
}
