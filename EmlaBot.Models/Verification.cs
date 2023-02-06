using System;
using System.Runtime.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class Verification
    {
        /// <summary>
        /// Gets or sets the URI for the uploaded picture.
        /// </summary>
        /// <value>The URI for the uploaded picture.</value>
        [DataMember(Name = "picture")]
        public Uri Picture { get; set; }

        /// <summary>
        /// Gets or sets the verification code that should be present in the image.
        /// </summary>
        /// <value>The verification code that should be present in the image.</value>
        [DataMember(Name = "code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the time-stamp of when the image was uploaded.
        /// </summary>
        /// <value>The time-stamp of when the image was uploaded.</value>
        [DataMember(Name = "timestamp")]
        public int Timestamp { get; set; }
    }
}