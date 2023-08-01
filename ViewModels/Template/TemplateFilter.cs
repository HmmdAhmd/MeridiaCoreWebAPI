namespace MeridiaCoreWebAPI.ViewModels.Template
{
    public class TemplateFilter
    {
        public string OrderByColumn { get; set; }
        public string OrderByType { get; set; }
        public int SkipRecords { get; set; }
        public int PageSize { get; set; }
        public bool IsArchived { get; set; }
        public List<string> TagsSearched { get; set; }
    }
}
