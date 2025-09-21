using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class Visibilities
    {
        [DataMember(Name = "userpagevisible")]
        [JsonPropertyName("userpagevisible")]
        public Toggle UserPageVisible { get; set; }

        [DataMember(Name = "sessionpagevisible")]
        [JsonPropertyName("sessionpagevisible")]
        public Toggle SessionPageVisible { get; set; }

        [DataMember(Name = "feedpagevisible")]
        [JsonPropertyName("feedpagevisible")]
        public Toggle FeedPageVisible { get; set; }

        [DataMember(Name = "verificiationvisible")]
        [JsonPropertyName("verificiationvisible")]
        public Toggle VerificationVisible { get; set; }

        [DataMember(Name = "highscore")]
        [JsonPropertyName("highscore")]
        public Toggle HighScore { get; set; }

        [DataMember(Name = "profilepictures")]
        [JsonPropertyName("profilepictures")]
        public Toggle ProfilePictures { get; set; }

        [DataMember(Name = "showholdersessiononprofile")]
        [JsonPropertyName("showholdersessiononprofile")]
        public Toggle ShowHolderSessionOnProfile { get; set; }
    }
}