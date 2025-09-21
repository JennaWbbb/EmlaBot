using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class SearchResult
    {
        [DataMember(Name = "userid")]
        [JsonPropertyName("userid")]
        public string UserId { get; set; }

        [DataMember(Name = "name")]
        [JsonPropertyName("name")]
        public string UserName { get; set; }
    }
}