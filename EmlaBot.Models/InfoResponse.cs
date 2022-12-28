using System.Runtime.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class InfoResponse
    {
        [DataMember(Name = "user")]
        public User User { get; set; }

        [DataMember(Name = "chastitysession")]
        public ChastitySessionDetails ChastitySession { get; set; }
    }
}