using System.Runtime.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class ChastitySession
    {
        [DataMember(Name = "chastitysessionid")]
        public string ChastitySessionId { get; set; }

        [DataMember(Name = "clsedate")]
        public int CloseDate { get; set; }

        [DataMember(Name = "created")]
        public int Created { get; set; }

        [DataMember(Name = "duration")]
        public int Duration { get; set; }

        [DataMember(Name = "maxduration")]
        public int MaxDuration { get; set; }

        [DataMember(Name = "minduration")]
        public int MinDuration { get; set; }

        [DataMember(Name = "offer")]
        public int Offer { get; set; }

        [DataMember(Name = "randomduration")]
        public int RandomDuration { get; set; }

        [DataMember(Name = "startdate")]
        public int StartDate { get; set; }

        [DataMember(Name = "startduration")]
        public int StartDuration { get; set; }

        [DataMember(Name = "status")]
        public int Status { get; set; }

        [DataMember(Name = "timeinlock")]
        public int TimeInLock { get; set; }

        [DataMember(Name = "wearerid")]
        public string WearerId { get; set; }
    }
}