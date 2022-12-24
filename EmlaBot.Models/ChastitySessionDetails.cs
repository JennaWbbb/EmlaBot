using System.Collections.Generic;

namespace EmlaBot.Models
{
    public class ChastitySessionDetails : ChastitySession
    {
        public string CreatorId { get; set; }
        public string HolderId { get; set; }
        public bool InoneoercentRange { get; set; }
        public int SessionType { get; set; }
        public int Interval { get; set; }
        public string Keyword { get; set; }
        public string NewKeyword { get; set; }
        public int TestSession { get; set; }
        public int Feed { get; set; }
        public int FriendLink { get; set; }
        public int ReqLink { get; set; }
        public int MinimumHolderScore { get; set; }
        public int HolderGender { get; set; }
        public int Transfer { get; set; }
        public int HolderFriendLink { get; set; }
        public string OfferUserId { get; set; }
        public int Requirements { get; set; }
        public int FriendLinkAdd { get; set; }
        public int FriendLinkSub { get; set; }
        public int ReqLinkAdd { get; set; }
        public int ReqLinkSub { get; set; }
        public DurationType DurationType { get; set; }
        public int BeatBy { get; set; }
        public int SpecStartDuration { get; set; }
        public int SpecMinDuration { get; set; }
        public int SpecMaxDuration { get; set; }
        public int StartWeight { get; set; }
        public int TargetWeight { get; set; }
        public SelectedDisplayMode DisplayMode { get; set; }
        public int WithPenaltyPenalty { get; set; }
        public EnabledGames Games { get; set; }
        public int Voting { get; set; }
        public int MustGamesPerDay { get; set; }
        public int MustGamesPeriod { get; set; }
        public int GamesPerDay { get; set; }
        public int GamesPeriod { get; set; }
        public int RiscVoting { get; set; }
        public string Description { get; set; }
        public List<WheelOfFortune> WheelOfFortune { get; set; }
        public int HygieneOpening { get; set; }
        public int CleaningsPerDay { get; set; }
        public int CleaningPeriod { get; set; }
        public int TimeForCleaning { get; set; }
        public int CleaningAction { get; set; }
        public int CleaningPenalty { get; set; }
        public int PenaltyGamesMinimum { get; set; }
        public int EndDate { get; set; }
        public bool CanBeClosed { get; set; }
        public int PlayedGamesMust { get; set; }
        public int CurrentWeight { get; set; }
        public int WeightBalance { get; set; }
        public int LastVerification { get; set; }
        public int Cleanings { get; set; }
        public int LastWeightUpdate { get; set; }
        public int PlayedGames { get; set; }
        public int PictureBy { get; set; }
        public int InCleaning { get; set; }
        public int CleaningStarted { get; set; }
        public int ApplyRiskVoting { get; set; }
        public int TimeWithPenaltyFrom { get; set; }
        public int TimeWithPenaltyTo { get; set; }
        public int EndType { get; set; }
        public List<WheelOfFortune> WheelOfSessionEnd { get; set; }
        public int Pillory { get; set; }
        public int PilloryLeft { get; set; }
        public string PilloryMessage { get; set; }
        public int PilloryPenalty { get; set; }
        public int WearerRating { get; set; }
        public int HolderRating { get; set; }
        public int PercentagePerPeriod { get; set; }
        public int PercentagePeriod { get; set; }
        public int Chance { get; set; }
        public string SuccessMessage { get; set; }
        public List<HolderHistory> HolderHistory { get; set; }
        public int Locktober { get; set; }
        public string FriendLinkId { get; set; }
        public string ReqLinkId { get; set; }
    }
}