using MeridiaCoreWebAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MeridiaCoreWebAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Subscription> Subscription { get; set; }
        public virtual DbSet<Template> Template { get; set; }
        public virtual DbSet<Slide> Slide { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<TemplateMetaData> TemplateMetaData { get; set; }
        public virtual DbSet<PollingSessionMessage> PollingSessionMessage { get; set; }
        public virtual DbSet<PollingData> PollingData { get; set; }
        public virtual DbSet<PollingSessionParticipantsHistory> PollingSessionParticipantsHistory { get; set; }
        public virtual DbSet<PolledSlide> PolledSlide { get; set; }
        public virtual DbSet<PollingParticipant> PollingParticipant { get; set; }
        public virtual DbSet<ParticipantResponse> ParticipantResponse { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<TemplateTag> TemplateTag { get; set; }
        public virtual DbSet<PolledTemplateMetaData> PolledTemplateMetaData { get; set; }
        public virtual DbSet<PollingDataTag> PollingDataTag { get; set; }
        public virtual DbSet<ResetPassword> ResetPassword { get; set; }
        public virtual DbSet<TemplateSetting> TemplateSetting { get; set; }
        public virtual DbSet<SubscriptionType> SubscriptionType { get; set; }
        public virtual DbSet<SharedTemplate> SharedTemplate { get; set; }
        public virtual DbSet<Setting> Setting { get; set; }
        public virtual DbSet<SubscriptionSetting> SubscriptionSetting { get; set; }
        public virtual DbSet<SyncedData> SyncedData { get; set; }
        public virtual DbSet<CSVNightly> CSVNightly { get; set; }
        public virtual DbSet<ParticipantList> ParticipantList { get; set; }
        public virtual DbSet<ParticipantListData> ParticipantListData { get; set; }
        public virtual DbSet<ParticipantListMetaData> ParticipantListMetaData { get; set; }
        public virtual DbSet<PLJoinSessionData> PLJoinSessionData { get; set; }
        public virtual DbSet<VideoFilter> VideoFilter { get; set; }
        public virtual DbSet<MeridiaSalesRecord> MeridiaSalesRecord { get; set; }
        public virtual DbSet<Playlist> Playlist { get; set; }
        public virtual DbSet<PlaylistTemplates> PlaylistTemplates { get; set; }
        public virtual DbSet<PolledPlaylist> PolledPlaylist { get; set; }
        public virtual DbSet<ActionType> ActionType { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<NotificationSubscriptionAssociation> NotificationSubscriptionAssociation { get; set; }
        public virtual DbSet<SentNotification> SentNotification { get; set; }
        public virtual DbSet<NotificationMetaData> NotificationMetaData { get; set; }
        public virtual DbSet<NotificationObserverType> NotificationObserverType { get; set; }
        public virtual DbSet<EZVoteConnectBuild> EZVoteConnectBuild { get; set; }
        public virtual DbSet<ActivityLogs> ActivityLogs { get; set; }
        public virtual DbSet<PendingUnsyncedTemplate> PendingUnsyncedTemplate { get; set; }
        public virtual DbSet<PendingUnsyncedPoll> PendingUnsyncedPoll { get; set; }
        public virtual DbSet<SubscriptionTemplateSetting> SubscriptionTemplateSetting { get; set; }
        public virtual DbSet<GroupParticipantAssociation> GroupParticipantAssociation { get; set; }
        public virtual DbSet<GroupTemplateAssociation> GroupTemplateAssociation { get; set; }
        public virtual DbSet<SharedParticipantGroup> SharedParticipantGroup { get; set; }
        public virtual DbSet<GroupTag> GroupTag { get; set; }
        public virtual DbSet<PLDataDetails> PLDataDetails { get; set; }
        public virtual DbSet<GlobalListMetaData> GlobalListMetaData { get; set; }
        public virtual DbSet<DashboardItem> DashboardItem { get; set; }
        public virtual DbSet<ItemFilter> ItemFilter { get; set; }
        public virtual DbSet<SubscriptionState> SubscriptionState { get; set; }
        public virtual DbSet<SubscriptionPlan> SubscriptionPlan { get; set; }
        public virtual DbSet<AppSetting> AppSetting { get; set; }
        public virtual DbSet<AppSettingValueType> AppSettingValueType { get; set; }
        public virtual DbSet<SubPlanAppSettingAssociation> SubPlanAppSettingAssociation { get; set; }
        public virtual DbSet<SubscriptionAppSettingAssociation> SubscriptionAppSettingAssociation { get; set; }
        public virtual DbSet<AppSettingState> AppSettingState { get; set; }
        public virtual DbSet<SubscriptionStorageMetric> SubscriptionStorageMetric { get; set; }
        public virtual DbSet<MeridiaClientRecord> MeridiaClientRecord { get; set; }
        public virtual DbSet<MeridiaClientRecordAppSettingAssociation> MeridiaClientRecordAppSettingAssociation { get; set; }
        public virtual DbSet<DefaultPasswordPolicy> DefaultPasswordPolicy { get; set; }
        public virtual DbSet<UserPasswordPolicy> UserPasswordPolicy { get; set; }
        public virtual DbSet<ParticipantInvitationLink> ParticipantInvitationLinks { get; set; }
        public virtual DbSet<ParticipantInvitationLog> ParticipantInvitationLogs { get; set; }
        public virtual DbSet<UserPasswordHistory> UserPasswordHistory { get; set; }
        public virtual DbSet<Report> Report { get; set; }
        public virtual DbSet<ReportType> ReportType { get; set; }
        public virtual DbSet<RenewSubscriptionLink> RenewSubscriptionLink { get; set; }
        public virtual DbSet<Moderator> Moderator { get; set; }
        public virtual DbSet<ModeratorRole> ModeratorRole { get; set; }
        public virtual DbSet<PollingSessionModeratorRole> PollingSessionModeratorRole { get; set; }
        public virtual DbSet<ModeratorInvitationLink> ModeratorInvitationLink { get; set; }
        public virtual DbSet<PollingSessionModerators> PollingSessionModerators { get; set; }
    }
}
