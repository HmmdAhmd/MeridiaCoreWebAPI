using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class AudienceView
    {
        [Key]
        public int AudienceViewId { get; set; }
        [ForeignKey("Template")]
        public int TemplateId { get; set; }
        public int ForegroundRed { get; set; }
        public int ForegroundGreen { get; set; }
        public int ForegroundBlue { get; set; }
        public int DataPoint1ForegroundRed { get; set; }
        public int DataPoint1ForegroundGreen { get; set; }
        public int DataPoint1ForegroundBlue { get; set; }
        public int DataPoint2ForegroundRed { get; set; }
        public int DataPoint2ForegroundGreen { get; set; }
        public int DataPoint2ForegroundBlue { get; set; }
        public int DataPoint3ForegroundRed { get; set; }
        public int DataPoint3ForegroundGreen { get; set; }
        public int DataPoint3ForegroundBlue { get; set; }
        public int DataPoint4ForegroundRed { get; set; }
        public int DataPoint4ForegroundGreen { get; set; }
        public int DataPoint4ForegroundBlue { get; set; }
        public int DataPoint5ForegroundRed { get; set; }
        public int DataPoint5ForegroundGreen { get; set; }
        public int DataPoint5ForegroundBlue { get; set; }
        public int DataPoint6ForegroundRed { get; set; }
        public int DataPoint6ForegroundGreen { get; set; }
        public int DataPoint6ForegroundBlue { get; set; }
        public int DataPoint7ForegroundRed { get; set; }
        public int DataPoint7ForegroundGreen { get; set; }
        public int DataPoint7ForegroundBlue { get; set; }
        public int DataPoint8ForegroundRed { get; set; }
        public int DataPoint8ForegroundGreen { get; set; }
        public int DataPoint8ForegroundBlue { get; set; }
        public int DataPoint9ForegroundRed { get; set; }
        public int DataPoint9ForegroundGreen { get; set; }
        public int DataPoint9ForegroundBlue { get; set; }
        public int DataPoint10ForegroundRed { get; set; }
        public int DataPoint10ForegroundGreen { get; set; }
        public int DataPoint10ForegroundBlue { get; set; }
        public double DropShadowOpacity { get; set; }
        public int BackgroundStyle { get; set; }
        public int GraphType { get; set; }
        public virtual Template Template { get; set; }
    }
}
