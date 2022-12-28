using System.Runtime.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class SelectedDisplayMode
    {
        [DataMember(Name = "timepassed")]
        public int TimePassed { get; set; }

        [DataMember(Name = "timeleft")]
        public int TimeLeft { get; set; }

        [DataMember(Name = "showapproximate")]
        public int ShowApproximate { get; set; }

        [DataMember(Name = "surpriseme")]
        public int SurpriseMe { get; set; }
    }
}