namespace MeridiaCoreWebAPI.ViewModels.Template
{
    public class TemplateGetMetaDataViewModel
    {
        public int TemplateMetaDataId { get; set; }
        public string MetaDataKey { get; set; }
        public string MetaDataValue { get; set; }
        public bool IsRequired { get; set; }
        public int ValueType { get; set; }
    }
}
