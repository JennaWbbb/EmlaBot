using System.Runtime.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class HolderHistory
    {
        [DataMember(Name = "holderid")]
        public string HolderId { get; set; }

        [DataMember(Name = "adopted")]
        public int Adopted { get; set; }

        [DataMember(Name = "rating")]
        public int Rating { get; set; }
    }
}