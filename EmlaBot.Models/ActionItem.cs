using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace EmlaBot.Models
{

    public class ActionItem
    {
        /// <summary>
        /// Gets or sets the action to be performed by the request.
        /// </summary>
        /// <remarks>The value specifies the type of operation, such as "apiadd", "apisub", "vote", or "wheeloffortune".
        /// The set of valid actions depends on the context in which this property is used.</remarks>
        [DataMember(Name = "action")]
        [JsonPropertyName("action")]
        public string Action { get; set; }            // e.g., "apiadd", "apisub", "vote", "wheeloffortune"

        /// <summary>
        /// When the action occurred, represented as a Unix timestamp.
        /// </summary>
        [DataMember(Name = "time")]
        [JsonPropertyName("time")]
        public long Time { get; set; }               // Unix timestamp (e.g., 1765350685)

        // Optional fields
        /// <summary>
        /// Gets or sets the duration, in seconds, associated with the operation or event.
        /// </summary>
        /// <remarks>
        /// Subtracts are still expressed as a negative amount, so -3600 is the removal of 1 hour
        /// If the sesion is running "without times", this field will not be set
        /// </remarks>
        [DataMember(Name = "duration")]
        [JsonPropertyName("duration")]
        public int? Duration { get; set; }           // e.g., 3600 or negative values

        /// <summary>
        /// Gets or sets the duration, in seconds, associated with the operation or event.
        /// </summary>
        /// <remarks>
        /// Returned on apiaddmaximum, apisubmaximum, apiaddminimum, apisubminimum
        /// Subtracts are still expressed as a negative amount, so -3600 is the removal of 1 hour
        /// </remarks>
        [DataMember(Name = "timevalue")]
        [JsonPropertyName("timevalue")]
        public int? TimeValue { get; set; }          // e.g., -10, 160

        /// <summary>
        /// Gets or sets the user name associated with the cause of the entry.
        /// </summary>
        /// <remarks>
        /// Only set on certain actions, such as vote, pilloryvote when the action is initiated bya specific user
        /// </remarks>
        [DataMember(Name = "user")]
        [JsonPropertyName("user")]
        public string User { get; set; }             // e.g., "samson"

        /// <summary>
        /// The text message associated with the action.
        /// </summary>
        /// <remarks>
        /// Typicaly associated to wheel of fortune actions
        /// </remarks>
        [DataMember(Name = "messgae")]
        [JsonPropertyName("message")]
        public string Message { get; set; }          // e.g., "vote a game"

        /// <summary>
        /// The text comment associated with the action.
        /// </summary>
        /// <remarks>
        /// Typically associated to apiadd, apisub and updatesessionholder actions
        /// </remarks>
        [DataMember(Name = "comment")]
        [JsonPropertyName("comment")]
        public string Comment { get; set; }          // e.g., "Beep"

        /// <summary>
        /// Gets or sets the duration, in seconds, for which the user is going to be in the pillory for.
        /// </summary>
        [DataMember(Name = "pillory")]
        [JsonPropertyName("pillory")]
        public int? Pillory { get; set; }            // e.g., 3600

        /// <summary>
        /// Gets or sets the number of required links added.
        /// </summary>
        [DataMember(Name = "links")]
        [JsonPropertyName("links")]
        public int? Links { get; set; }              // e.g., 1

        /// <summary>
        /// The session end has been granted - remaing time is now zero, even if the minimum duration 
        /// has not yet been reached, and required links are removed
        /// </summary>
        [DataMember(Name = "release")]
        [JsonPropertyName("release")]
        public bool? Release { get; set; }           // e.g., true

        /// <summary>
        /// The duration value associated with a requirement action.
        /// </summary>
        /// <remarks>
        /// Unlike <see cref="Duration"/>, this value might be ommitted if the user's session is configured 
        /// to not have visibility of durations.
        /// </remarks>
        [DataMember(Name = "value")]
        [JsonPropertyName("value")]
        public int? Value { get; set; }              // e.g., 8
    }
}
