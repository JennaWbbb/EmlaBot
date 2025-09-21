using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class UserProfile : Account
    {
        /// <summary>
        /// Gets or sets the time-stamp of the last action by the user
        /// </summary>
        /// <value>The time-stamp of the last action by the user.</value>
        [DataMember(Name = "lastclick")]
        [JsonPropertyName("lastclick")]
        public int LastClick { get; set; }

        [DataMember(Name = "subscriptionvalue")]
        [JsonPropertyName("subscriptionvalue")]
        public int SubscriptionValue { get; set; }

        [DataMember(Name = "financialinterests")]
        [JsonPropertyName("financialinterests")]
        public int FinancialInterests { get; set; }

        /// <summary>
        /// Gets or sets the wearer rating count.
        /// </summary>
        /// <value>The wearer rating count.</value>
        [DataMember(Name = "wearerrates")]
        [JsonPropertyName("wearerrates")]
        public int WearerRatingCount { get; set; }

        /// <summary>
        /// Gets or sets the wearer rating.
        /// </summary>
        /// <value>The wearer rating on a 0 to 10 scale.</value>
        [DataMember(Name = "wearerrating")]
        [JsonPropertyName("wearerrating")]
        public int WearerRating { get; set; }

        /// <summary>
        /// Gets or sets the holder rating count.
        /// </summary>
        /// <value>The holder rating count.</value>
        [DataMember(Name = "holderrates")]
        [JsonPropertyName("holderrates")]
        public int HolderRatingCount { get; set; }

        /// <summary>
        /// Gets or sets the holder rating.
        /// </summary>
        /// <value>The holder rating on a 0 to 10 scale.</value>
        [DataMember(Name = "holderrating")]
        [JsonPropertyName("holderrating")]
        public int HolderRating { get; set; }

        /// <summary>
        /// Gets or sets whether the age has been verified.
        /// </summary>
        /// <value>The age verified.</value>
        [DataMember(Name = "ageverified")]
        [JsonPropertyName("ageverified")]
        public Toggle AgeVerified { get; set; }

        /// <summary>
        /// Gets or sets the cont of sessions completed.
        /// </summary>
        /// <value>The count of sessions completed.</value>
        [DataMember(Name = "sessions")]
        [JsonPropertyName("sessions")]
        public int SessionCount { get; set; }

        /// <summary>
        /// Gets or sets the cont of failed sessions.
        /// </summary>
        /// <value>The count of sessions failed completed.</value>
        [DataMember(Name = "failedsessions")]
        [JsonPropertyName("failedsessions")]
        public int FailedSessionCount { get; set; }

        /// <summary>
        /// Gets or sets the duration of the longest session, in seconds.
        /// </summary>
        /// <value>The duration of the longest session, in seconds.</value>
        [DataMember(Name = "maxsession")]
        [JsonPropertyName("maxsession")]
        public int LongestSessionDuration { get; set; }

        /// <summary>
        /// Gets or sets the duration of the shortest session, in seconds.
        /// </summary>
        /// <value>The duration of the shortest session, in seconds.</value>
        [DataMember(Name = "minsession")]
        [JsonPropertyName("minsession")]
        public int ShortestSessionDuration { get; set; }

        /// <summary>
        /// Gets or sets the total duration in sessions, in seconds.
        /// </summary>
        /// <value>The total duration in sessions, in seconds.</value>
        [DataMember(Name = "sumsession")]
        [JsonPropertyName("sumsession")]
        public int TotalLockedDuration { get; set; }

        /// <summary>
        /// Gets or sets the time-stamp of when the account was created
        /// </summary>
        /// <value>The time-stamp of when the account was created.</value>
        [DataMember(Name = "membersince")]
        [JsonPropertyName("membersince")]
        public int MemberSince { get; set; }

        /// <summary>
        /// Gets or sets the time-stamp of the user's birthday
        /// </summary>
        /// <value>The time-stamp of the user's birthday.</value>
        [DataMember(Name = "dateofbirth")]
        [JsonPropertyName("dateofbirth")]
        public long DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [DataMember(Name = "description")]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        [DataMember(Name = "gender")]
        [JsonPropertyName("gender")]
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets or sets the ISO 639-1 language code.
        /// </summary>
        /// <value>The ISO 639-1 language code.</value>
        [DataMember(Name = "language")]
        [JsonPropertyName("language")]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the chastity role.
        /// </summary>
        /// <value>The chastity role.</value>
        [DataMember(Name = "chastityrole")]
        [JsonPropertyName("chastityrole")]
        public ChastityRole ChastityRole { get; set; }

        /// <summary>
        /// Gets or sets the difference to UTC for the user.
        /// </summary>
        /// <value>The difference to UTC for the user.</value>
        /// <remarks>
        /// No automatic adjustment is made for daylight savings, so can be wrong if the user hasn't
        /// updated it, if they change observing daylight savings
        /// </remarks>
        [DataMember(Name = "timezone")]
        [JsonPropertyName("timezone")]
        public UtcOffset Timezone { get; set; }

        /// <summary>
        /// Gets or sets whether the user has different things visible.
        /// </summary>
        /// <value>The visibilities.</value>
        [DataMember(Name = "visibilities")]
        [JsonPropertyName("visibilities")]
        public Visibilities Visibilities { get; set; }

        [DataMember(Name = "discordvisibile")]
        [JsonPropertyName("discordvisible")]
        public Toggle DiscordVisible { get; set; }

        [DataMember(Name = "showsessionimages")]
        [JsonPropertyName("showsessionimages")]
        public Toggle ShowSessionImages { get; set; }

        /// <summary>
        /// Gets or sets the discord user identifier.
        /// </summary>
        /// <value>The discord user identifier.</value>
        [DataMember(Name = "discord_userid")]
        [JsonPropertyName("discord_userid")]
        public string DiscordUserId { get; set; }

        /// <summary>
        /// Gets or sets the social account details.
        /// </summary>
        /// <value>The socials.</value>
        [DataMember(Name = "socials")]
        [JsonPropertyName("socials")]
        public SocialProfiles Socials { get; set; }
    }
}
