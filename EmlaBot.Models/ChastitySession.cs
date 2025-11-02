using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class ChastitySession
    {
        /// <summary>
        /// The session's unique ID.
        /// </summary>
        [DataMember(Name = "chastitysessionid")]
        [JsonPropertyName("chastitysessionid")]
        public string ChastitySessionId { get; set; }

        /// <summary>
        /// The unix timestamp representing the close date of the chastity session.
        /// </summary>
        [DataMember(Name = "clsedate")]
        [JsonPropertyName("closedate")]
        public int CloseDate { get; set; }

        /// <summary>
        /// The unix timestamp representing the creation date of the chastity session.
        /// </summary>
        [DataMember(Name = "created")]
        [JsonPropertyName("created")]
        public int Created { get; set; }

        /// <summary>
        /// The duration of the session, in seconds
        /// </summary>
        [DataMember(Name = "duration")]
        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        /// <summary>
        /// The maximum duration of the session, in seconds
        /// </summary>
        /// <remarks>
        /// A value of zero indicates no maximum duration.
        /// </remarks>
        [DataMember(Name = "maxduration")]
        [JsonPropertyName("maxduration")]
        public int MaxDuration { get; set; }

        /// <summary>
        /// The length of the session in seconds
        /// </summary>
        [DataMember(Name = "minduration")]
        [JsonPropertyName("minduration")]
        public int MinDuration { get; set; }

        /// <summary>
        /// The offer type of the chastity session.
        /// </summary>
        [DataMember(Name = "offer")]
        [JsonPropertyName("offer")]
        public Offer Offer { get; set; }

        /// <summary>
        /// Whther the display mode is set to approximate.
        /// </summary>
        [DataMember(Name = "randomduration")]
        [JsonPropertyName("randomduration")]
        public int RandomDuration { get; set; }

        /// <summary>
        /// The unix timestamp representing the start date of the chastity session.
        /// </summary>
        [DataMember(Name = "startdate")]
        [JsonPropertyName("startdate")]
        public int StartDate { get; set; }

        /// <summary>
        /// The initial duration of the chastity session in seconds.
        /// </summary>
        [DataMember(Name = "startduration")]
        [JsonPropertyName("startduration")]
        public int StartDuration { get; set; }

        /// <summary>
        /// The status of the chastity session.
        /// </summary>
        [DataMember(Name = "status")]
        [JsonPropertyName("status")]
        public Status Status { get; set; }

        /// <summary>
        /// The total time in seconds that a session was active for.
        /// </summary>
        /// <remarks>
        /// For running sessions, this seems to be zero. For closed sessions, this is the total time the session was active.
        /// </remarks>
        [DataMember(Name = "timeinlock")]
        [JsonPropertyName("timeinlock")]
        public int TimeInLock { get; set; }

        /// <summary>
        /// The user ID of the wearer in the chastity session.
        /// </summary>
        [DataMember(Name = "wearerid")]
        [JsonPropertyName("wearreid")]
        public string WearerId { get; set; }
    }
}