using System.Runtime.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class Account
    {
        [DataMember(Name = "userid")]
        public string UserId { get; set; }

        [DataMember(Name = "username")]
        public string UserName { get; set; }
    }
}