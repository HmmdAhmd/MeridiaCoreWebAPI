using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class AnswerBlMapping
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Answer")]
        public int AnswerId { get; set; }
        [ForeignKey("AnswerBlActionType")]
        public int AnswerBlActionTypeId { get; set; }
        public string Value { get; set; }
        public virtual Answer Answer { get; set; }
    }
}
