using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class User : Account, IApiToken
    {
        [DataMember(Name = "lastclick")]
        public int LastClick { get; set; }

        [DataMember(Name = "subscriptionvalue")]
        public int SubscriptionValue { get; set; }

        [DataMember(Name = "financialinterests")]
        public int FinancialInterests { get; set; }

        [DataMember(Name = "wearerrates")]
        public int WearerRates { get; set; }

        [DataMember(Name = "wearerrating")]
        public int WearerRating { get; set; }

        [DataMember(Name = "holderrates")]
        public int HolderRates { get; set; }

        [DataMember(Name = "holderrating")]
        public int HolderRating { get; set; }

        [DataMember(Name = "ageverified")]
        public int AgeVerified { get; set; }

        /// <summary>
        /// Gets or sets the cont of sessions completed.
        /// </summary>
        /// <value>The count of sessions completed.</value>
        [DataMember(Name = "sessions")]
        public int Sessions { get; set; }

        /// <summary>
        /// Gets or sets the cont of failed sessions.
        /// </summary>
        /// <value>The count of sessions failed completed.</value>
        [DataMember(Name = "failedsessions")]
        public int FailedSessions { get; set; }

        /// <summary>
        /// Gets or sets the duration of the longest session, in seconds.
        /// </summary>
        /// <value>The duration of the longest session, in seconds.</value>
        [DataMember(Name = "maxsession")]
        public int MaxSession { get; set; }

        /// <summary>
        /// Gets or sets the duration of the shortest session, in seconds.
        /// </summary>
        /// <value>The duration of the shortest session, in seconds.</value>
        [DataMember(Name = "minsession")]
        public int MinSession { get; set; }

        /// <summary>
        /// Gets or sets the total duration in sessions, in seconds.
        /// </summary>
        /// <value>The total duration in sessions, in seconds.</value>
        [DataMember(Name = "sumsession")]
        public int SumSession { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of when the account was created
        /// </summary>
        /// <value>The timestamp of when the account was created.</value>
        [DataMember(Name = "membersince")]
        public int MemberSince { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the user's birthday
        /// </summary>
        /// <value>The timestamp of the user's birthday.</value>
        [DataMember(Name = "dateofbirth")]
        public int DateOfBirth { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "gender")]
        public int Gender { get; set; }

        [DataMember(Name = "language")]
        public string Language { get; set; }

        [DataMember(Name = "chastityrole")]
        public Role ChastityRole { get; set; }

        [DataMember(Name = "timezone")]
        public int Timezone { get; set; }

        [DataMember(Name = "visibilities")]
        public Visibilities Visibilities { get; set; }

        [DataMember(Name = "discordvisibile")]
        public int DiscordVisible { get; set; }

        [DataMember(Name = "showsessionimages")]
        public int ShowSessionImages { get; set; }

        [DataMember(Name = "discorduserid")]
        public string DiscordUserId { get; set; }

        [DataMember(Name = "socials")]
        public SocialProfiles Socials { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "emailverified")]
        public int EmailVerified { get; set; }

        [DataMember(Name = "trustlevel")]
        public int TrustLevel { get; set; }

        [DataMember(Name = "holdersessions")]
        public List<string> HolderSessionKeys { get; set; }

        [DataMember(Name = "holdersessionsleft")]
        public int HolderSessionsLeft { get; set; }

        [DataMember(Name = "premiumservices")]
        public PremiumServices PremiumServices { get; set; }

        [DataMember(Name = "theme")]
        public int Theme { get; set; }

        [DataMember(Name = "apikey")]
        public string ApiKey { get; set; }

        [DataMember(Name = "level")]
        public int Level { get; set; }

        [DataMember(Name = "notificiations")]
        public Notifications Notifications { get; set; }

        [DataMember(Name = "subscription")]
        public List<object> Subscription { get; set; }

        /// <summary>
        /// Gets or sets the weight declaration.
        /// </summary>
        /// <value>The weight declaration.</value>
        /// <remarks>TODO: Need to check if this is the units, or the weight</remarks>
        [DataMember(Name = "weightdeclaration")]
        public int WeightDeclaration { get; set; }

        [DataMember(Name = "timeformet")]
        public int TimeFormat { get; set; }

        [DataMember(Name = "lastchastikeysync")]
        public int LastChastikeySync { get; set; }

        [DataMember(Name = "ageverificationsleft")]
        public int AgeVerificationsLeft { get; set; }

        [DataMember(Name = "accounttype")]
        public int AccountType { get; set; }

        [DataMember(Name = "mainaccountid")]
        public string MainAccountId { get; set; }

        [DataMember(Name = "accounts")]
        public List<Account> Accounts { get; set; }
    }
}