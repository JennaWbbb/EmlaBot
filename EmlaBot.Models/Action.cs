using System.Runtime.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class Action
    {
        [DataMember(Name = "duration")]
        public int Duration { get; set; }

        [DataMember(Name = "userid")]
        public string UserId { get; set; }

        [DataMember(Name = "time")]
        public int Time { get; set; }

        [DataMember(Name = "protocolid")]
        public string ProtocolId { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "comment")]
        public string Comment { get; set; }

        [DataMember(Name = "pillory")]
        public int? Pillory { get; set; }

        [DataMember(Name = "timevalue")]
        public int? TimeValue { get; set; }
    }
}