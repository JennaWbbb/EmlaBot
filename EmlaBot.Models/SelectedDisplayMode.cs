using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class SelectedDisplayMode
    {
        [DataMember(Name = "timepassed")]
        [JsonPropertyName("timepassed")]
        public Toggle TimePassed { get; set; }

        [DataMember(Name = "timeleft")]
        [JsonPropertyName("timeleft")]
        public Toggle TimeLeft { get; set; }

        [DataMember(Name = "showapproximate")]
        [JsonPropertyName("showapproximate")]
        public Toggle ShowApproximate { get; set; }

        [DataMember(Name = "surpriseme")]
        [JsonPropertyName("surpriseme")]
        public Toggle SurpriseMe { get; set; }
    }
}