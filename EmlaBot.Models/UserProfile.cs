using System.Collections.Generic;

namespace EmlaBot.Models
{
    public class User : Account, IApiToken
    {
        public int LastClick { get; set; }
        public int SubscriptioVvalue { get; set; }
        public int FinancialInterests { get; set; }
        public int WearerRates { get; set; }
        public int WearerRating { get; set; }
        public int HolderRates { get; set; }
        public int HolderRating { get; set; }
        public int AgeVerified { get; set; }

        /// <summary>
        /// Gets or sets the cont of sessions completed.
        /// </summary>
        /// <value>The count of sessions completed.</value>
        public int Sessions { get; set; }

        /// <summary>
        /// Gets or sets the cont of failed sessions.
        /// </summary>
        /// <value>The count of sessions failed completed.</value>
        public int FailedSessions { get; set; }

        /// <summary>
        /// Gets or sets the duration of the longest session, in seconds.
        /// </summary>
        /// <value>The duration of the longest session, in seconds.</value>
        public int MaxSession { get; set; }

        /// <summary>
        /// Gets or sets the duration of the shortest session, in seconds.
        /// </summary>
        /// <value>The duration of the shortest session, in seconds.</value>
        public int MinSession { get; set; }

        /// <summary>
        /// Gets or sets the total duration in sessions, in seconds.
        /// </summary>
        /// <value>The total duration in sessions, in seconds.</value>
        public int SumSession { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of when the account was created
        /// </summary>
        /// <value>The timestamp of when the account was created.</value>
        public int MemberSince { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the user's birthday
        /// </summary>
        /// <value>The timestamp of the user's birthday.</value>
        public int DateOfBirth { get; set; }

        public string Description { get; set; }
        public int Gender { get; set; }
        public string Language { get; set; }
        public int ChastityRole { get; set; }
        public int Timezone { get; set; }
        public Visibilities Visibilities { get; set; }
        public int DiscordVisible { get; set; }
        public int ShowSessionImages { get; set; }
        public string DiscordUserId { get; set; }
        public SocialProfiles Socials { get; set; }
        public string Email { get; set; }
        public int EmailVerified { get; set; }
        public int TrustLevel { get; set; }
        public List<string> HolderSessions { get; set; }
        public int HolderSessionsLeft { get; set; }
        public PremiumServices PremiumServices { get; set; }
        public int Theme { get; set; }
        public string ApiKey { get; set; }
        public int Level { get; set; }
        public Notifications Notifications { get; set; }
        public List<object> Subscription { get; set; }
        public int WeightDeclaration { get; set; }
        public int TimeFormat { get; set; }
        public int LastChastikeySync { get; set; }
        public int AgeVerificationsLeft { get; set; }
        public int AccountType { get; set; }
        public string MainAccountId { get; set; }
        public List<Account> Accounts { get; set; }
    }
}