using System.Runtime.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class Notifications
    {
        [DataMember(Name = "receivedmessages")]
        public Toggle ReceivedMessages { get; set; }

        [DataMember(Name = "keyidused")]
        public Toggle KeyIdUsed { get; set; }

        [DataMember(Name = "combinationpicture")]
        public Toggle CombinationPicture { get; set; }

        [DataMember(Name = "offeredsessions")]
        public Toggle OfferedSessions { get; set; }

        [DataMember(Name = "wearerhasendedsession")]
        public Toggle WearerHasEndedSession { get; set; }

        [DataMember(Name = "emlalockupdates")]
        public Toggle EmlalockUpdates { get; set; }
    }
}