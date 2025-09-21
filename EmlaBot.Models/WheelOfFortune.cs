using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class WheelOfFortune
    {
        [DataMember(Name = "duration")]
        [JsonPropertyName("duration")]
        public string Duration { get; set; }

        [DataMember(Name = "text")]
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [DataMember(Name = "operator")]
        [JsonPropertyName("operator")]
        public string Operator { get; set; }

        [DataMember(Name = "color")]
        [JsonPropertyName("color")]
        public string Color { get; set; }
    }
}