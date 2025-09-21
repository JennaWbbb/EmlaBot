using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class Notifications
    {
        [DataMember(Name = "receivedmessages")]
        [JsonPropertyName("receivedmessages")]
        public Toggle ReceivedMessages { get; set; }

        [DataMember(Name = "keyidused")]
        [JsonPropertyName("keyidused")]
        public Toggle KeyIdUsed { get; set; }

        [DataMember(Name = "combinationpicture")]
        [JsonPropertyName("combinationpicture")]
        public Toggle CombinationPicture { get; set; }

        [DataMember(Name = "offeredsessions")]
        [JsonPropertyName("offeredsessions")]
        public Toggle OfferedSessions { get; set; }

        [DataMember(Name = "wearerhasendedsession")]
        [JsonPropertyName("wearerhasendedsession")]
        public Toggle WearerHasEndedSession { get; set; }

        [DataMember(Name = "emlalockupdates")]
        [JsonPropertyName("emlalockupdates")]
        public Toggle EmlalockUpdates { get; set; }
    }
}