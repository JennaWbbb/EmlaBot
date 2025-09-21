using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class EnabledGames
    {
        [DataMember(Name = "blackjack")]
        [JsonPropertyName("blackjack")]
        public Toggle Blackjack { get; set; }

        [DataMember(Name = "slotmachine")]
        [JsonPropertyName("slotmachine")]
        public Toggle SlotMachine { get; set; }

        [DataMember(Name = "bingo")]
        [JsonPropertyName("bingo")]
        public Toggle Bingo { get; set; }

        [DataMember(Name = "voting")]
        [JsonPropertyName("voting")]
        public Toggle Voting { get; set; }

        [DataMember(Name = "wheeloffortune")]
        [JsonPropertyName("wheeloffortune")]
        public Toggle WheelOfFortune { get; set; }
    }
}