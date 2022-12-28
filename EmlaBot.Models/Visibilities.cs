using System.Runtime.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class Visibilities
    {
        [DataMember(Name = "userpagevisible")]
        public int UserPageVisible { get; set; }

        [DataMember(Name = "sessionpagevisible")]
        public int SessionPageVisible { get; set; }

        [DataMember(Name = "feedpagevisible")]
        public int FeedPageVisible { get; set; }

        [DataMember(Name = "verificiationvisible")]
        public int VerificationVisible { get; set; }

        [DataMember(Name = "highscore")]
        public int HighScore { get; set; }

        [DataMember(Name = "profilepictures")]
        public int ProfilePictures { get; set; }

        [DataMember(Name = "showholdersessiononprofile")]
        public int ShowHolderSessionOnProfile { get; set; }
    }
}