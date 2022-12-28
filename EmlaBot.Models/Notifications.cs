using System.Runtime.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class Notifications
    {
        [DataMember(Name = "receivedmessages")]
        public int ReceivedMessages { get; set; }

        [DataMember(Name = "keyidused")]
        public int KeyIdUsed { get; set; }

        [DataMember(Name = "combinationpicture")]
        public int CombinationPicture { get; set; }

        [DataMember(Name = "offeredsessions")]
        public int OfferedSessions { get; set; }

        [DataMember(Name = "wearerhasendedsession")]
        public int WearerHasEndedSession { get; set; }

        [DataMember(Name = "emlalockupdates")]
        public int EmlalockUpdates { get; set; }
    }
}