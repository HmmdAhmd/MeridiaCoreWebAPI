using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeridiaCoreWebAPI.Models
{
    public class Template
    {
        [Key]
        public int TemplateId { get; set; }
        public string? TemplateKey { get; set; }
        public string? TemplateName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsArchived { get; set; }
        public string? FileId { get; set; }
        public bool IsFileDeleted { get; set; }
        [ForeignKey("ApplicationUser")]
        public string? UserId { get; set; }
        public virtual AudienceView AudienceView { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Slide> Slides { get; set; }
        public virtual ICollection<TemplateMetaData> TemplateMetaData { get; set; }
        public virtual ICollection<PollingData> PollingData { get; set; }
        public virtual ICollection<TemplateTag> TemplateTags { get; set; }
        public virtual TemplateSetting TemplateSettings { get; set; }
        public bool IsSelfPaced { get; set; } = false;
        public virtual ICollection<GroupTemplateAssociation> AssociatedGroups { get; set; }        
    }
}
