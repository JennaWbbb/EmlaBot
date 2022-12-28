using System.Runtime.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class EnabledGames
    {
        [DataMember(Name = "blackjack")]
        public int Blackjack { get; set; }

        [DataMember(Name = "slotmachine")]
        public int SlotMachine { get; set; }

        [DataMember(Name = "bingo")]
        public int Bingo { get; set; }

        [DataMember(Name = "voting")]
        public int Voting { get; set; }

        [DataMember(Name = "wheeloffortune")]
        public int WheelOfFortune { get; set; }
    }
}