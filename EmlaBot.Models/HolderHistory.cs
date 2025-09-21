using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class HolderHistory
    {
        [DataMember(Name = "holderid")]
        [JsonPropertyName("holderid")]
        public string HolderId { get; set; }

        [DataMember(Name = "adopted")]
        [JsonPropertyName("adopted")]
        public int Adopted { get; set; }

        [DataMember(Name = "rating")]
        [JsonPropertyName("rating")]
        public int Rating { get; set; }
    }
}