namespace MeridiaCoreWebAPI.ViewModels.Template
{
    public class TemplateGetViewModel
    {
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserId { get; set; }
        public string SlideImageURL { get; set; }
        public List<TemplateGetMetaDataViewModel> TemplateMetaData { get; set; }
        public AudienceViewModel AudienceView { get; set; }
        public List<TemplateTagGetViewModel> TemplateTags { get; set; }
        public bool IsSelfPaced { get; set; }
        public int SlidesCount { get; set; }
        public string UserName { get; set; }
        public int PolledSessionsCount { get; set; }
        public bool IsPendingSync { get; set; }
        public string MetaDataString { get; set; } = string.Empty;
        public string UploadedByString { get; set; }
        public bool IsShareable { get; set; }
        public bool IsEditable { get; set; }
        public string AssociatedGroupsString { get; set; } = string.Empty;
        public string AssociatedTagsString { get; set; } = string.Empty;
        public DateTime? CompletionDate { get; set; }
    }
}
