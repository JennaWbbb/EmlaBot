using System.Runtime.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class SocialProfiles
    {
        [DataMember(Name = "voiyal")]
        public string Voiyal { get; set; }

        [DataMember(Name = "onlyfans")]
        public string Onlyfans { get; set; }

        [DataMember(Name = "twitter")]
        public string Twitter { get; set; }

        [DataMember(Name = "fetlife")]
        public string Fetlife { get; set; }

        [DataMember(Name = "discord")]
        public string Discord { get; set; }
    }
}