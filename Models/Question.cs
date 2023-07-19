using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        public string Text { get; set; }
        [ForeignKey("Slide")]
        public int SlideId { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public virtual Slide Slide { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
