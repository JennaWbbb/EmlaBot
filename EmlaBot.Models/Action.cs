using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class Action
    {
        [DataMember(Name = "duration")]
        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [DataMember(Name = "userid")]
        [JsonPropertyName("userid")]
        public string UserId { get; set; }

        [DataMember(Name = "time")]
        [JsonPropertyName("time")]
        public int Time { get; set; }

        [DataMember(Name = "protocolid")]
        [JsonPropertyName("protocolid")]
        public string ProtocolId { get; set; }

        [DataMember(Name = "message")]
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [DataMember(Name = "comment")]
        [JsonPropertyName("comment")]
        public string Comment { get; set; }

        [DataMember(Name = "pillory")]
        [JsonPropertyName("pillory")]
        public int? Pillory { get; set; }

        [DataMember(Name = "timevalue")]
        [JsonPropertyName("timevalue")]
        public int? TimeValue { get; set; }
    }
}