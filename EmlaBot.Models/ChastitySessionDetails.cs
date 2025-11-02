using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class ChastitySessionDetails : ChastitySession
    {
        [DataMember(Name = "creatorid")]
        [JsonPropertyName("creatorid")]
        public string CreatorId { get; set; }

        [DataMember(Name = "holderid")]
        [JsonPropertyName("holderid")]
        public string HolderId { get; set; }

        [DataMember(Name = "inoneoercentrange")]
        [JsonPropertyName("inoneoercentrange")]
        public bool InoneoercentRange { get; set; }

        [DataMember(Name = "sessiontype")]
        [JsonPropertyName("sessiontype")]
        public PictureType SessionType { get; set; }

        [DataMember(Name = "interval")]
        [JsonPropertyName("interval")]
        public int Interval { get; set; }

        [DataMember(Name = "keyword")]
        [JsonPropertyName("keyword")]
        public string EmergencyPassword { get; set; }

        [DataMember(Name = "newkeyword")]
        [JsonPropertyName("newkeyword")]
        public string NewEmergencyPassword { get; set; }

        [DataMember(Name = "testsession")]
        [JsonPropertyName("testsession")]
        public int TestSession { get; set; }

        [DataMember(Name = "feed")]
        [JsonPropertyName("feed")]
        public int Feed { get; set; }

        [DataMember(Name = "friendlink")]
        [JsonPropertyName("friendlink")]
        public int FriendLink { get; set; }

        [DataMember(Name = "reqlink")]
        [JsonPropertyName("reqlink")]
        public int RequiremntLinkKey { get; set; }

        [DataMember(Name = "minimumholderscore")]
        [JsonPropertyName("minimumholderscore")]
        public int MinimumHolderScore { get; set; }

        [DataMember(Name = "holdergender")]
        [JsonPropertyName("holdergender")]
        public int HolderGender { get; set; }

        [DataMember(Name = "transfer")]
        [JsonPropertyName("transfer")]
        public Toggle Transfer { get; set; }

        [DataMember(Name = "holderfriendlink")]
        [JsonPropertyName("holderfriendlink")]
        public Toggle HolderFriendLink { get; set; }

        [DataMember(Name = "offeruserid")]
        [JsonPropertyName("offeruserid")]
        public string OfferUserId { get; set; }

        [DataMember(Name = "requirements")]
        [JsonPropertyName("requirements")]
        public int Requirements { get; set; }

        [DataMember(Name = "friendlinkadd")]
        [JsonPropertyName("friendlinkadd")]
        public int FriendLinkAddSeconds { get; set; }

        [DataMember(Name = "friendlinksub")]
        [JsonPropertyName("friendlinksub")]
        public int FriendLinkSubtractSeconds { get; set; }

        [DataMember(Name = "reqlinkadd")]
        [JsonPropertyName("reqlinkadd")]
        public int RequirmentLinkAddSeconds { get; set; }

        [DataMember(Name = "reqlinksub")]
        [JsonPropertyName("reqlinksub")]
        public int RequirementLinkSubtractSeconds { get; set; }

        [DataMember(Name = "durationtype")]
        [JsonPropertyName("durationtype")]
        public DurationType DurationType { get; set; }

        [DataMember(Name = "beatby")]
        [JsonPropertyName("beatby")]
        public int BeatBy { get; set; }

        [DataMember(Name = "specstartduration")]
        [JsonPropertyName("specstartduration")]
        public int SpecStartDuration { get; set; }

        [DataMember(Name = "specminduration")]
        [JsonPropertyName("specminduration")]
        public int SpecMinDuration { get; set; }

        [DataMember(Name = "specmaxduration")]
        [JsonPropertyName("specmaxduration")]
        public int SpecMaxDuration { get; set; }

        [DataMember(Name = "startweight")]
        [JsonPropertyName("startweight")]
        public int StartWeight { get; set; }

        [DataMember(Name = "targetweight")]
        [JsonPropertyName("targetweight")]
        public int TargetWeight { get; set; }

        [DataMember(Name = "displaymode")]
        [JsonPropertyName("displaymode")]
        public SelectedDisplayMode DisplayMode { get; set; }

        [DataMember(Name = "withpenaltypenalty")]
        [JsonPropertyName("withpenaltypenalty")]
        public int WithPenaltyPenalty { get; set; }

        [DataMember(Name = "games")]
        [JsonPropertyName("games")]
        public EnabledGames Games { get; set; }

        [DataMember(Name = "voting")]
        [JsonPropertyName("voting")]
        public int Voting { get; set; }

        [DataMember(Name = "mustgamesperday")]
        [JsonPropertyName("mustgamesperday")]
        public int MustGamesPerDay { get; set; }

        [DataMember(Name = "mustgamesperiod")]
        [JsonPropertyName("mustgamesperiod")]
        public int MustGamesPeriod { get; set; }

        [DataMember(Name = "gamesperday")]
        [JsonPropertyName("gamesperday")]
        public int GamesPerDay { get; set; }

        [DataMember(Name = "gamesperiod")]
        [JsonPropertyName("gamesperiod")]
        public int GamesPeriod { get; set; }

        [DataMember(Name = "riscvoting")]
        [JsonPropertyName("riscvoting")]
        public int RiskVoting { get; set; }

        [DataMember(Name = "description")]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [DataMember(Name = "wheeloffortune")]
        [JsonPropertyName("wheeloffortune")]
        public List<WheelOfFortune> WheelOfFortune { get; set; }

        [DataMember(Name = "hygieneopening")]
        [JsonPropertyName("hygieneopening")]
        public int HygieneOpening { get; set; }

        [DataMember(Name = "cleaningsperday")]
        [JsonPropertyName("cleaningsperday")]
        public int CleaningsPerDay { get; set; }

        [DataMember(Name = "cleaningperiod")]
        [JsonPropertyName("cleaningperiod")]
        public int CleaningPeriod { get; set; }

        [DataMember(Name = "timeforcleaning")]
        [JsonPropertyName("timeforcleaning")]
        public int TimeForCleaning { get; set; }

        [DataMember(Name = "cleaningaction")]
        [JsonPropertyName("cleaningaction")]
        public int CleaningAction { get; set; }

        [DataMember(Name = "cleaningpenalty")]
        [JsonPropertyName("cleaningpenalty")]
        public int CleaningPenalty { get; set; }

        [DataMember(Name = "penaltygamesminimum")]
        [JsonPropertyName("penaltygamesminimum")]
        public int PenaltyGamesMinimum { get; set; }

        [DataMember(Name = "enddate")]
        [JsonPropertyName("enddate")]
        public string RawEndDate { get; set; }

        [JsonIgnore]
        public int EndDate
        {
            get
            {
                if (int.TryParse(RawEndDate, out var endDate))
                {
                    return endDate;
                }
                else
                {
                    return -1;
                }
            }
        }

        [DataMember(Name = "canbeclosed")]
        [JsonPropertyName("canbeclosed")]
        public bool CanBeClosed { get; set; }

        [DataMember(Name = "playedgamesmust")]
        [JsonPropertyName("playedgamesmust")]
        public int PlayedGamesMust { get; set; }

        [DataMember(Name = "currentweight")]
        [JsonPropertyName("currentweight")]
        public int CurrentWeight { get; set; }

        [DataMember(Name = "weightbalance")]
        [JsonPropertyName("weightbalance")]
        public int WeightBalance { get; set; }

        [DataMember(Name = "lastverification")]
        [JsonPropertyName("lastverification")]
        public int LastVerification { get; set; }

        [DataMember(Name = "cleanings")]
        [JsonPropertyName("cleanings")]
        public int Cleanings { get; set; }

        [DataMember(Name = "lastweightupdate")]
        [JsonPropertyName("lastweightupdate")]
        public int LastWeightUpdate { get; set; }

        [DataMember(Name = "playedgames")]
        [JsonPropertyName("playedgames")]
        public int PlayedGames { get; set; }

        [DataMember(Name = "pictureby")]
        [JsonPropertyName("pictureby")]
        public int PictureBy { get; set; }

        [DataMember(Name = "incleaning")]
        [JsonPropertyName("incleaning")]
        public Toggle InCleaning { get; set; }

        [DataMember(Name = "cleaningstarted")]
        [JsonPropertyName("cleaningstarted")]
        public int CleaningStarted { get; set; }

        [DataMember(Name = "applyriskvoting")]
        [JsonPropertyName("applyriskvoting")]
        public int ApplyRiskVoting { get; set; }

        [DataMember(Name = "timewithpenaltyfrom")]
        [JsonPropertyName("timewithpenaltyfrom")]
        public int TimeWithPenaltyFrom { get; set; }

        [DataMember(Name = "timewithpenaltyto")]
        [JsonPropertyName("timewithpenaltyto")]
        public int TimeWithPenaltyTo { get; set; }

        [DataMember(Name = "endtype")]
        [JsonPropertyName("endtype")]
        public int EndType { get; set; }

        [DataMember(Name = "wheelofsessionend")]
        [JsonPropertyName("wheelofsessionend")]
        public List<WheelOfFortune> WheelOfSessionEnd { get; set; }

        [DataMember(Name = "pillory")]
        [JsonPropertyName("pillory")]
        public Toggle Pillory { get; set; }

        [DataMember(Name = "pilloryleft")]
        [JsonPropertyName("pilloryleft")]
        public int PilloryLeft { get; set; }

        [DataMember(Name = "pillorymessage")]
        [JsonPropertyName("pillorymessage")]
        public string PilloryMessage { get; set; }

        [DataMember(Name = "pillorypenalty")]
        [JsonPropertyName("pillorypenalty")]
        public int PilloryPenalty { get; set; }

        [DataMember(Name = "wearerrating")]
        [JsonPropertyName("wearerrating")]
        public int WearerRating { get; set; }

        [DataMember(Name = "holderrating")]
        [JsonPropertyName("holderrating")]
        public int HolderRating { get; set; }

        [DataMember(Name = "percentageperperiod")]
        [JsonPropertyName("percentageperperiod")]
        public int PercentagePerPeriod { get; set; }

        [DataMember(Name = "percentageperiod")]
        [JsonPropertyName("percentageperiod")]
        public int PercentagePeriod { get; set; }

        [DataMember(Name = "chance")]
        [JsonPropertyName("chance")]
        public int Chance { get; set; }

        [DataMember(Name = "successmessage")]
        [JsonPropertyName("successmessage")]
        public string SuccessMessage { get; set; }

        [DataMember(Name = "holderhistory")]
        [JsonPropertyName("holderhistory")]
        public List<HolderHistory> HolderHistory { get; set; }

        [DataMember(Name = "locktober")]
        [JsonPropertyName("locktober")]
        public Toggle Locktober { get; set; }

        [DataMember(Name = "friendlinkid")]
        [JsonPropertyName("friendlinkid")]
        public string FriendLinkId { get; set; }

        [DataMember(Name = "reqlinkid")]
        [JsonPropertyName("reqlinkid")]
        public string RequirmentLinkId { get; set; }
    }
}