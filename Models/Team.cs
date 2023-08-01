using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string? ColorSCR { get; set; }
        public string? ColorSCG { get; set; }
        public string? ColorSCB { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}
