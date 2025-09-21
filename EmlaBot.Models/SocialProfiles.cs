using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class SocialProfiles
    {
        [DataMember(Name = "voiyal")]
        [JsonPropertyName("voiyal")]
        public string Voiyal { get; set; }

        [DataMember(Name = "onlyfans")]
        [JsonPropertyName("onlyfans")]
        public string Onlyfans { get; set; }

        [DataMember(Name = "twitter")]
        [JsonPropertyName("twitter")]
        public string Twitter { get; set; }

        [DataMember(Name = "fetlife")]
        [JsonPropertyName("fetlife")]
        public string Fetlife { get; set; }

        [DataMember(Name = "discord")]
        [JsonPropertyName("discord")]
        public string Discord { get; set; }
    }
}