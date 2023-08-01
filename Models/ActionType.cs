using System.ComponentModel.DataAnnotations;

namespace MeridiaCoreWebAPI.Models
{
    public class ActionType
    {
        [Key]
        public int ActionTypeId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
