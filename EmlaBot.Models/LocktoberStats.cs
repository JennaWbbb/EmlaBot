using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace EmlaBot.Models
{
    public class LocktoberStats
    {
        [DataMember(Name = "participated")]
        [JsonPropertyName("participated")]
        public int Participated { get; set; }

        [DataMember(Name = "active")]
        [JsonPropertyName("active")]
        public int Active { get; set; }
    }
}
