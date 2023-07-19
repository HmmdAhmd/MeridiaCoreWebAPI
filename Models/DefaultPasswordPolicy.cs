using System.ComponentModel.DataAnnotations;

namespace MeridiaCoreWebAPI.Models
{
    public class DefaultPasswordPolicy
    {
        [Key]
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
