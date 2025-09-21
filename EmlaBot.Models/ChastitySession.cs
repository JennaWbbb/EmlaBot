using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class ChastitySession
    {
        [DataMember(Name = "chastitysessionid")]
        [JsonPropertyName("chastitysessionid")]
        public string ChastitySessionId { get; set; }

        [DataMember(Name = "clsedate")]
        [JsonPropertyName("closedate")]
        public int CloseDate { get; set; }

        [DataMember(Name = "created")]
        [JsonPropertyName("created")]
        public int Created { get; set; }

        [DataMember(Name = "duration")]
        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [DataMember(Name = "maxduration")]
        [JsonPropertyName("maxduration")]
        public int MaxDuration { get; set; }

        [DataMember(Name = "minduration")]
        [JsonPropertyName("minduration")]
        public int MinDuration { get; set; }

        [DataMember(Name = "offer")]
        [JsonPropertyName("offer")]
        public int Offer { get; set; }

        [DataMember(Name = "randomduration")]
        [JsonPropertyName("randomduration")]
        public int RandomDuration { get; set; }

        [DataMember(Name = "startdate")]
        [JsonPropertyName("startdate")]
        public int StartDate { get; set; }

        [DataMember(Name = "startduration")]
        [JsonPropertyName("startduration")]
        public int StartDuration { get; set; }

        [DataMember(Name = "status")]
        [JsonPropertyName("status")]
        public int Status { get; set; }

        [DataMember(Name = "timeinlock")]
        [JsonPropertyName("timeinlock")]
        public int TimeInLock { get; set; }

        [DataMember(Name = "wearerid")]
        [JsonPropertyName("wearreid")]
        public string WearerId { get; set; }
    }
}