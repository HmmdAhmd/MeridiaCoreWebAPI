using System.ComponentModel.DataAnnotations;

namespace MeridiaCoreWebAPI.Models
{
    public class ActionType
    {
        [Required]
        public int ActionTypeId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
