using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class AggregatedAction
    {
        [DataMember(Name = "action")]
        [JsonPropertyName("action")]
        public string Action { get; set; }

        [DataMember(Name = "time")]
        [JsonPropertyName("time")]
        public int Time { get; set; }

        [DataMember(Name = "until")]
        [JsonPropertyName("until")]
        public int Until { get; set; }

        [DataMember(Name = "duration")]
        [JsonPropertyName("duration")]
        public int? Duration { get; set; }

        [DataMember(Name = "actions")]
        [JsonPropertyName("actions")]
        public List<Action> Actions { get; set; }

        [DataMember(Name = "message")]
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [DataMember(Name = "comment")]
        [JsonPropertyName("comment")]
        public string Comment { get; set; }

        [DataMember(Name = "pillory")]
        [JsonPropertyName("pillory")]
        public int? Pillory { get; set; }
    }
}