﻿using System.Runtime.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class InfoResponse
    {
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        [DataMember(Name = "user")]
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the chastity session.
        /// </summary>
        /// <value>The chastity session.</value>
        [DataMember(Name = "chastitysession")]
        public ChastitySessionDetails ChastitySession { get; set; }
    }
}