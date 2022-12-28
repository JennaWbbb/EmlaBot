using System.Runtime.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class WheelOfFortune
    {
        [DataMember(Name = "duration")]
        public string Duration { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "operator")]
        public string Operator { get; set; }

        [DataMember(Name = "color")]
        public string Color { get; set; }
    }
}