using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class ChastitySessionDetails : ChastitySession
    {
        [DataMember(Name = "creatorid")]
        public string CreatorId { get; set; }

        [DataMember(Name = "holderid")]
        public string HolderId { get; set; }

        [DataMember(Name = "inoneoercentrange")]
        public bool InoneoercentRange { get; set; }

        [DataMember(Name = "sessiontype")]
        public int SessionType { get; set; }

        [DataMember(Name = "interval")]
        public int Interval { get; set; }

        [DataMember(Name = "keyword")]
        public string EmergencyPassword { get; set; }

        [DataMember(Name = "newkeyword")]
        public string NewEmergencyPassword { get; set; }

        [DataMember(Name = "testsession")]
        public int TestSession { get; set; }

        [DataMember(Name = "feed")]
        public int Feed { get; set; }

        [DataMember(Name = "friendlink")]
        public int FriendLink { get; set; }

        [DataMember(Name = "reqlink")]
        public int RequiremntLinkKey { get; set; }

        [DataMember(Name = "minimumholderscore")]
        public int MinimumHolderScore { get; set; }

        [DataMember(Name = "holdergender")]
        public int HolderGender { get; set; }

        [DataMember(Name = "transfer")]
        public int Transfer { get; set; }

        [DataMember(Name = "holderfriendlink")]
        public int HolderFriendLink { get; set; }

        [DataMember(Name = "offeruserid")]
        public string OfferUserId { get; set; }

        [DataMember(Name = "requirements")]
        public int Requirements { get; set; }

        [DataMember(Name = "friendlinkadd")]
        public int FriendLinkAddSeconds { get; set; }

        [DataMember(Name = "friendlinksub")]
        public int FriendLinkSubtractSeconds { get; set; }

        [DataMember(Name = "reqlinkadd")]
        public int RequirmentLinkAddSeconds { get; set; }

        [DataMember(Name = "reqlinksub")]
        public int RequirementLinkSubtractSeconds { get; set; }

        [DataMember(Name = "durationtype")]
        public DurationType DurationType { get; set; }

        [DataMember(Name = "beatby")]
        public int BeatBy { get; set; }

        [DataMember(Name = "specstartduration")]
        public int SpecStartDuration { get; set; }

        [DataMember(Name = "specminduration")]
        public int SpecMinDuration { get; set; }

        [DataMember(Name = "specmaxduration")]
        public int SpecMaxDuration { get; set; }

        [DataMember(Name = "startweight")]
        public int StartWeight { get; set; }

        [DataMember(Name = "targetweight")]
        public int TargetWeight { get; set; }

        [DataMember(Name = "displaymode")]
        public SelectedDisplayMode DisplayMode { get; set; }

        [DataMember(Name = "withpenaltypenalty")]
        public int WithPenaltyPenalty { get; set; }

        [DataMember(Name = "games")]
        public EnabledGames Games { get; set; }

        [DataMember(Name = "voting")]
        public int Voting { get; set; }

        [DataMember(Name = "mustgamesperday")]
        public int MustGamesPerDay { get; set; }

        [DataMember(Name = "mustgamesperiod")]
        public int MustGamesPeriod { get; set; }

        [DataMember(Name = "gamesperday")]
        public int GamesPerDay { get; set; }

        [DataMember(Name = "gamesperiod")]
        public int GamesPeriod { get; set; }

        [DataMember(Name = "riscvoting")]
        public int RiskVoting { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "wheeloffortune")]
        public List<WheelOfFortune> WheelOfFortune { get; set; }

        [DataMember(Name = "hygieneopening")]
        public int HygieneOpening { get; set; }

        [DataMember(Name = "cleaningsperday")]
        public int CleaningsPerDay { get; set; }

        [DataMember(Name = "cleaningperiod")]
        public int CleaningPeriod { get; set; }

        [DataMember(Name = "timeforcleaning")]
        public int TimeForCleaning { get; set; }

        [DataMember(Name = "cleaningaction")]
        public int CleaningAction { get; set; }

        [DataMember(Name = "cleaningpenalty")]
        public int CleaningPenalty { get; set; }

        [DataMember(Name = "penaltygamesminimum")]
        public int PenaltyGamesMinimum { get; set; }

        [DataMember(Name = "enddate")]
        public int EndDate { get; set; }

        [DataMember(Name = "canbeclosed")]
        public bool CanBeClosed { get; set; }

        [DataMember(Name = "playedgamesmust")]
        public int PlayedGamesMust { get; set; }

        [DataMember(Name = "currentweight")]
        public int CurrentWeight { get; set; }

        [DataMember(Name = "weightbalance")]
        public int WeightBalance { get; set; }

        [DataMember(Name = "lastverification")]
        public int LastVerification { get; set; }

        [DataMember(Name = "cleanings")]
        public int Cleanings { get; set; }

        [DataMember(Name = "lastweightupdate")]
        public int LastWeightUpdate { get; set; }

        [DataMember(Name = "playedgames")]
        public int PlayedGames { get; set; }

        [DataMember(Name = "pictureby")]
        public int PictureBy { get; set; }

        [DataMember(Name = "incleaning")]
        public int InCleaning { get; set; }

        [DataMember(Name = "cleaningstarted")]
        public int CleaningStarted { get; set; }

        [DataMember(Name = "applyriskvoting")]
        public int ApplyRiskVoting { get; set; }

        [DataMember(Name = "timewithpenaltyfrom")]
        public int TimeWithPenaltyFrom { get; set; }

        [DataMember(Name = "timewithpenaltyto")]
        public int TimeWithPenaltyTo { get; set; }

        [DataMember(Name = "endtype")]
        public int EndType { get; set; }

        [DataMember(Name = "wheelofsessionend")]
        public List<WheelOfFortune> WheelOfSessionEnd { get; set; }

        [DataMember(Name = "pillory")]
        public int Pillory { get; set; }

        [DataMember(Name = "pilloryleft")]
        public int PilloryLeft { get; set; }

        [DataMember(Name = "pillorymessage")]
        public string PilloryMessage { get; set; }

        [DataMember(Name = "pillorypenalty")]
        public int PilloryPenalty { get; set; }

        [DataMember(Name = "wearerrating")]
        public int WearerRating { get; set; }

        [DataMember(Name = "holderrating")]
        public int HolderRating { get; set; }

        [DataMember(Name = "percentageperperiod")]
        public int PercentagePerPeriod { get; set; }

        [DataMember(Name = "percentageperiod")]
        public int PercentagePeriod { get; set; }

        [DataMember(Name = "chance")]
        public int Chance { get; set; }

        [DataMember(Name = "successmessage")]
        public string SuccessMessage { get; set; }

        [DataMember(Name = "holderhistory")]
        public List<HolderHistory> HolderHistory { get; set; }

        [DataMember(Name = "locktober")]
        public int Locktober { get; set; }

        [DataMember(Name = "friendlinkid")]
        public string FriendLinkId { get; set; }

        [DataMember(Name = "reqlinkid")]
        public string RequirmentLinkId { get; set; }
    }
}