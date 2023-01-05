using System.Runtime.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class EnabledGames
    {
        [DataMember(Name = "blackjack")]
        public Toggle Blackjack { get; set; }

        [DataMember(Name = "slotmachine")]
        public Toggle SlotMachine { get; set; }

        [DataMember(Name = "bingo")]
        public Toggle Bingo { get; set; }

        [DataMember(Name = "voting")]
        public Toggle Voting { get; set; }

        [DataMember(Name = "wheeloffortune")]
        public Toggle WheelOfFortune { get; set; }
    }
}