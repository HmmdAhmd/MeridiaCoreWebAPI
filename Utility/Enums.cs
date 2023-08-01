namespace MeridiaCoreWebAPI.Utility
{
    public class Enums
    {
        public enum SubscriptionTypes
        {
            Single = 1,
            Parent = 2,
            Child = 3

        }

        public enum PollingState
        {
            Open = 1,
            Idle = 2,
            Closed = 3
        }

        public enum AnswerOrdinalLabelTypeEnumeration
        {
            Alpha,
            Numeric
        }

        public enum SlideTypeEnumeration
        {
            Undefined = 0,
            SingleResponse = 1,
            MultiResponse = 2,
            FilteredByQuestion = 3,
            CompareResponses = 4,
            IndividualScores = 5,
            FastestResponder = 6,
            TeamScores = 7,
            Rating = 8,
            Ranking = 9,
            Texting = 10
        }

        public enum MetadataValueDataTypeEnumeration
        {
            _Text = 0,
            _Date = 1,
            _Time = 2,
            _DateTime = 3,
            _Integer = 4,
            _Decimal = 5
        }

        public enum PollingDispositionEnumeration
        {
            Undefined = 0,
            MustPoll = 1,
            CanNotPoll = 2,
            HasBeenPolled = 3
        }

        public enum BackgroundStyleEnumeration
        {
            Transparent = 0,
            LightGlass = 1,
            DarkGlass = 2,
            SolidBlack = 3,
            SolidWhite = 4
        }

        public enum ResponseCollectionTypeEnumeration
        {
            MostRecentParticipantResponse = 0,
            AllParticipantResponses = 1
        }

        public enum OrdinalLabelTypeEnumeration
        {
            Alpha = 1,
            Numeric = 2
        }

        public enum NotificationActionTypeEnum
        {
            Dismiss = 1,
            Sync,
            SyncGroup,
            SyncParticipant,
            SyncTemplateGroupAssociation,
            SyncTemplateGroupDissociation,
            SyncSubscriptionGroupAssociation,
            SyncSubscriptionGroupDissociation,
            SyncGloballistMetadata,
            ReportGenerated
        }

        public enum NotificationObserverTypeEnum
        {
            All = 1,
            Desktop,
            Mobile,
            DesktopMobile
        }

        public enum AppSettingsEnum
        {
            WebPolling = 1,
            HybridPolling,
            TownVoteDesktopApp,
            TimelineFeature,
            AnywhereDesktopApp,
            SelfpacedPolling,
            ClickerParticipantsCount,
            AllowExportingReports,
            AllowParticipantList,
            AllowCustomBranding,
            MobileParticipantsAllowed,
            CloudStorageAllowed,
            PurgeTrialData,
            AllowEzVote,
            AllowDesktopGames,
            AllowPlaylist            
        }

        public enum SubscriptionStateEnum
        {
            Active = 0,
            Deleted,
            DeletedPermanently,
            Expired
        }

        public enum SubscriptionPlanEnum
        {
            Expired = 1,
            Standard,
            Trial,
            TownVOTE,
            ExpiredTownVOTE 
        }

        public enum PollingSessionTypeEnum
        {
            Regular = 1,
            LongRunning            
        }

        public enum AspectRatio
        {
            Ratio_16x9 = 1,
            Ratio_4x3
        }

        public enum InvitationEmailsStatus
        {
            Pending = 1,
            InProgress,
            Error,
            Completed
        }

        public enum ReportTypeEnum
        {
            ResponseSummary=1,
            TextMessage,
            ParticipantSummary,
            Timeline
        }

        public enum ReportGenerationStatus
        {
            NotStarted=1,
            InProgress,
            Generated,
            Failed
        }

        public enum InvoiceOption
        {
            Finalize = 1,
            Send = 2,
            Pay = 3
        }

        public enum InvoiceStatus
        {
            draft,
            open,
            paid
        }
    }
}
