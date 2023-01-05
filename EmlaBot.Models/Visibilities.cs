using System.Runtime.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class Visibilities
    {
        [DataMember(Name = "userpagevisible")]
        public Toggle UserPageVisible { get; set; }

        [DataMember(Name = "sessionpagevisible")]
        public Toggle SessionPageVisible { get; set; }

        [DataMember(Name = "feedpagevisible")]
        public Toggle FeedPageVisible { get; set; }

        [DataMember(Name = "verificiationvisible")]
        public Toggle VerificationVisible { get; set; }

        [DataMember(Name = "highscore")]
        public Toggle HighScore { get; set; }

        [DataMember(Name = "profilepictures")]
        public Toggle ProfilePictures { get; set; }

        [DataMember(Name = "showholdersessiononprofile")]
        public Toggle ShowHolderSessionOnProfile { get; set; }
    }
}