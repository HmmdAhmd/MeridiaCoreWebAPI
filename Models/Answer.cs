using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        public int AnswerOrdinal { get; set; }
        public int OrdinalLabelType { get; set; }
        public string AnswerLabel { get; set; }
        public string AnswerText { get; set; }
        public int AnswerWeight { get; set; }
        public int AnswerPoints { get; set; }
        public bool AnswerIsCorrect { get; set; }
        public int AnswerGroupId { get; set; }
        public DateTime LastModifiedDate { get; set; }
        [ForeignKey("Slide")]
        public int? NextSlideId { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public virtual Slide Slide { get; set; }
    }
}
