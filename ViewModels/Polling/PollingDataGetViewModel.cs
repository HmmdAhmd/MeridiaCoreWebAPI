namespace MeridiaCoreWebAPI.ViewModels.Polling
{
    public class PollingDataGetViewModel
    {
        public string ImageUrl { get; set; }
        public int TemplateId { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime PollingStartDate { get; set; }
        public DateTime PollingEndDate { get; set; }
        public string TemplateName { get; set; }
        public int PollingDataId { get; set; }
        public bool IsTimeline { get; set; }
        public bool IsSynced { get; set; }
        public int PolledSlidesCount { get; set; }
        public List<PolledTemplateGetMetaDataViewModel> PolledTemplateMetaData { get; set; }
        public List<PollingDataTagGetViewModel> PollingDataTags { get; set; }
        public string OperatorName { get; set; }
        public string JoinCode { get; set; }
        public string MetaDataString { get; set; }
        public bool ShowSyncedStatus { get; set; }
        public bool IsAggregated { get; set; }
    }
}
