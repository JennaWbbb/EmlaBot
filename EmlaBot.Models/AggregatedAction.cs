using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class AggregatedAction
    {
        [DataMember(Name = "action")]
        public string Action { get; set; }

        [DataMember(Name = "time")]
        public int Time { get; set; }

        [DataMember(Name = "until")]
        public int Until { get; set; }

        [DataMember(Name = "duration")]
        public int? Duration { get; set; }

        [DataMember(Name = "actions")]
        public List<Action> Actions { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "comment")]
        public string Comment { get; set; }

        [DataMember(Name = "pillory")]
        public int? Pillory { get; set; }
    }
}