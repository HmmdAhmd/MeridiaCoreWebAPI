using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class TemplateSetting
    {
        [Key]
        public int TemplateSettingId { get; set; }
        [ForeignKey("Template")]
        public int? TemplateId { get; set; }
        [Required]
        public string DefaultChartType { get; set; }
        [Required]
        public string ChartOption1Color { get; set; }
        [Required]
        public string ChartOption2Color { get; set; }
        [Required]
        public string ChartOption3Color { get; set; }
        [Required]
        public string ChartOption4Color { get; set; }
        [Required]
        public string ChartOption5Color { get; set; }
        [Required]
        public string ChartOption6Color { get; set; }
        [Required]
        public string ChartOption7Color { get; set; }
        [Required]
        public string ChartOption8Color { get; set; }
        [Required]
        public string ChartOption9Color { get; set; }
        [Required]
        public string ChartOption10Color { get; set; }
        [Required]
        public string ChartValuesType { get; set; }
        [Required]
        public int ChartValueDecimalPlaces { get; set; }
        [Required]
        public string ChartLabelType { get; set; }
        [Required]
        public bool ShowChart { get; set; }
        [Required]
        public bool RemoveVote { get; set; } = false;
        [Required]
        public bool EnableTexting { get; set; }
        public string MessageText { get; set; }
        [Required]
        public string MessagePosition { get; set; }
        [Required]
        public string MessageBackgroundColor { get; set; }
        [Required]
        public string MessageFontColor { get; set; }
        [Required]
        public double MessageFontSize { get; set; }
        [Required]
        public double MessageBackgroundOpacity { get; set; }
        public virtual Template Template { get; set; }
        public DateTime LastModifiedDate { get; set; }        
    }
}
