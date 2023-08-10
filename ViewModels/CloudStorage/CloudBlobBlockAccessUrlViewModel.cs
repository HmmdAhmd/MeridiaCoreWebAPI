namespace MeridiaCoreWebAPI.ViewModels.CloudStorage
{
    public class CloudBlobBlockAccessUrlViewModel
    {
        public string ImageUrl { get; set; }
        public string UserId { get; set; }
        public string RootDirectory { get; set; }
        public string SubDirectoryLevelOne { get; set; }
        public string SubDirectoryLevelTwo { get; set; }
        public DateTime URLExpiryDate { get; set; }
    }
}
