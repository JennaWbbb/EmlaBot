using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class User : Account, IApiToken
    {
        /// <summary>
        /// Gets or sets the time-stamp of the last action by the user
        /// </summary>
        /// <value>The time-stamp of the last action by the user.</value>
        [DataMember(Name = "lastclick")]
        public int LastClick { get; set; }

        [DataMember(Name = "subscriptionvalue")]
        public int SubscriptionValue { get; set; }

        [DataMember(Name = "financialinterests")]
        public int FinancialInterests { get; set; }

        /// <summary>
        /// Gets or sets the wearer rating count.
        /// </summary>
        /// <value>The wearer rating count.</value>
        [DataMember(Name = "wearerrates")]
        public int WearerRatingCount { get; set; }

        /// <summary>
        /// Gets or sets the wearer rating.
        /// </summary>
        /// <value>The wearer rating on a 0 to 10 scale.</value>
        [DataMember(Name = "wearerrating")]
        public int WearerRating { get; set; }

        /// <summary>
        /// Gets or sets the holder rating count.
        /// </summary>
        /// <value>The holder rating count.</value>
        [DataMember(Name = "holderrates")]
        public int HolderRatingCount { get; set; }

        /// <summary>
        /// Gets or sets the holder rating.
        /// </summary>
        /// <value>The holder rating on a 0 to 10 scale.</value>
        [DataMember(Name = "holderrating")]
        public int HolderRating { get; set; }

        /// <summary>
        /// Gets or sets whether the age has been verified.
        /// </summary>
        /// <value>The age verified.</value>
        [DataMember(Name = "ageverified")]
        public Toggle AgeVerified { get; set; }

        /// <summary>
        /// Gets or sets the cont of sessions completed.
        /// </summary>
        /// <value>The count of sessions completed.</value>
        [DataMember(Name = "sessions")]
        public int SessionCount { get; set; }

        /// <summary>
        /// Gets or sets the cont of failed sessions.
        /// </summary>
        /// <value>The count of sessions failed completed.</value>
        [DataMember(Name = "failedsessions")]
        public int FailedSessionCount { get; set; }

        /// <summary>
        /// Gets or sets the duration of the longest session, in seconds.
        /// </summary>
        /// <value>The duration of the longest session, in seconds.</value>
        [DataMember(Name = "maxsession")]
        public int LongestSessionDuration { get; set; }

        /// <summary>
        /// Gets or sets the duration of the shortest session, in seconds.
        /// </summary>
        /// <value>The duration of the shortest session, in seconds.</value>
        [DataMember(Name = "minsession")]
        public int ShortestSessionDuration { get; set; }

        /// <summary>
        /// Gets or sets the total duration in sessions, in seconds.
        /// </summary>
        /// <value>The total duration in sessions, in seconds.</value>
        [DataMember(Name = "sumsession")]
        public int TotalLockedDuration { get; set; }

        /// <summary>
        /// Gets or sets the time-stamp of when the account was created
        /// </summary>
        /// <value>The time-stamp of when the account was created.</value>
        [DataMember(Name = "membersince")]
        public int MemberSince { get; set; }

        /// <summary>
        /// Gets or sets the time-stamp of the user's birthday
        /// </summary>
        /// <value>The time-stamp of the user's birthday.</value>
        [DataMember(Name = "dateofbirth")]
        public long DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        [DataMember(Name = "gender")]
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets or sets the ISO 639-1 language code.
        /// </summary>
        /// <value>The ISO 639-1 language code.</value>
        [DataMember(Name = "language")]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the chastity role.
        /// </summary>
        /// <value>The chastity role.</value>
        [DataMember(Name = "chastityrole")]
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
        public UtcOffset Timezone { get; set; }

        /// <summary>
        /// Gets or sets whether the user has different things visible.
        /// </summary>
        /// <value>The visibilities.</value>
        [DataMember(Name = "visibilities")]
        public Visibilities Visibilities { get; set; }

        [DataMember(Name = "discordvisibile")]
        public Toggle DiscordVisible { get; set; }

        [DataMember(Name = "showsessionimages")]
        public Toggle ShowSessionImages { get; set; }

        /// <summary>
        /// Gets or sets the discord user identifier.
        /// </summary>
        /// <value>The discord user identifier.</value>
        [DataMember(Name = "discord_userid")]
        public string DiscordUserId { get; set; }

        /// <summary>
        /// Gets or sets the social account details.
        /// </summary>
        /// <value>The socials.</value>
        [DataMember(Name = "socials")]
        public SocialProfiles Socials { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>The email.</value>
        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "emailverified")]
        public Toggle EmailVerified { get; set; }

        [DataMember(Name = "trustlevel")]
        public int TrustLevel { get; set; }

        /// <summary>
        /// Gets or sets the session keys the user is holding.
        /// </summary>
        /// <value>The holder session keys.</value>
        [DataMember(Name = "holdersessions")]
        public List<string> HolderSessionKeys { get; set; }

        /// <summary>
        /// Gets or sets the count of sessions left that the use could hold.
        /// </summary>
        /// <value>The holder sessions left.</value>
        [DataMember(Name = "holdersessionsleft")]
        public int HolderSessionsLeft { get; set; }

        /// <summary>
        /// Gets or sets the premium services.
        /// </summary>
        /// <value>The premium services.</value>
        [DataMember(Name = "premiumservices")]
        public PremiumServices PremiumServices { get; set; }

        /// <summary>
        /// Gets or sets the theme.
        /// </summary>
        /// <value>The theme.</value>
        [DataMember(Name = "theme")]
        public Theme Theme { get; set; }

        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        /// <value>The API key.</value>
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
        [DataMember(Name = "weightdeclaration")]
        public WeightUnits WeightDeclaration { get; set; }

        /// <summary>
        /// Gets or sets the time format.
        /// </summary>
        /// <value>The time format.</value>
        [DataMember(Name = "timeformet")]
        public TimeFormat TimeFormat { get; set; }

        /// <summary>
        /// Gets or sets the time-stamp of the last synchronisation of data with Chastikey
        /// </summary>
        /// <value>The time-stamp of the last synchronisation of data with Chastikey.</value>
        [DataMember(Name = "lastchastikeysync")]
        public int LastChastikeySync { get; set; }

        [DataMember(Name = "ageverificationsleft")]
        public int AgeVerificationsLeft { get; set; }

        /// <summary>
        /// Gets or sets the type of the account.
        /// </summary>
        /// <value>The type of the account.</value>
        [DataMember(Name = "accounttype")]
        public AccountType AccountType { get; set; }

        /// <summary>
        /// Gets or sets the main account identifier.
        /// </summary>
        /// <value>The main account identifier.</value>
        [DataMember(Name = "mainaccountid")]
        public string MainAccountId { get; set; }

        /// <summary>
        /// Gets or sets any accounts that list this as their main account.
        /// </summary>
        /// <value>The accounts.</value>
        [DataMember(Name = "accounts")]
        public List<Account> Accounts { get; set; }
    }
}