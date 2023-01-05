using System.Runtime.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class SelectedDisplayMode
    {
        [DataMember(Name = "timepassed")]
        public Toggle TimePassed { get; set; }

        [DataMember(Name = "timeleft")]
        public Toggle TimeLeft { get; set; }

        [DataMember(Name = "showapproximate")]
        public Toggle ShowApproximate { get; set; }

        [DataMember(Name = "surpriseme")]
        public Toggle SurpriseMe { get; set; }
    }
}