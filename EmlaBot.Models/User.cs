using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace EmlaBot.Models
{
    [DataContract]
    public class User : UserProfile, IApiToken
    {
        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>The email.</value>
        [DataMember(Name = "email")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [DataMember(Name = "emailverified")]
        [JsonPropertyName("emailverified")]
        public Toggle EmailVerified { get; set; }

        [DataMember(Name = "trustlevel")]
        [JsonPropertyName("trustlevel")]
        public int TrustLevel { get; set; }

        /// <summary>
        /// Gets or sets the session keys the user is holding.
        /// </summary>
        /// <value>The holder session keys.</value>
        [DataMember(Name = "holdersessions")]
        [JsonPropertyName("holdersessions")]
        public List<string> HolderSessionKeys { get; set; }

        /// <summary>
        /// Gets or sets the count of sessions left that the use could hold.
        /// </summary>
        /// <value>The holder sessions left.</value>
        [DataMember(Name = "holdersessionsleft")]
        [JsonPropertyName("holdersessionsleft")]
        public int HolderSessionsLeft { get; set; }

        /// <summary>
        /// Gets or sets the premium services.
        /// </summary>
        /// <value>The premium services.</value>
        [DataMember(Name = "premiumservices")]
        [JsonPropertyName("premiumservices")]
        public PremiumServices PremiumServices { get; set; }

        /// <summary>
        /// Gets or sets the theme.
        /// </summary>
        /// <value>The theme.</value>
        [DataMember(Name = "theme")]
        [JsonPropertyName("theme")]
        public Theme Theme { get; set; }

        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        /// <value>The API key.</value>
        [DataMember(Name = "apikey")]
        [JsonPropertyName("apikey")]
        public string ApiKey { get; set; }

        [DataMember(Name = "level")]
        [JsonPropertyName("level")]
        public int Level { get; set; }

        [DataMember(Name = "notificiations")]
        [JsonPropertyName("notificiations")]
        public Notifications Notifications { get; set; }

        [DataMember(Name = "subscription")]
        [JsonPropertyName("subscription")]
        public List<object> Subscription { get; set; }

        /// <summary>
        /// Gets or sets the weight declaration.
        /// </summary>
        /// <value>The weight declaration.</value>
        [DataMember(Name = "weightdeclaration")]
        [JsonPropertyName("weightdeclaration")]
        public WeightUnits WeightDeclaration { get; set; }

        /// <summary>
        /// Gets or sets the time format.
        /// </summary>
        /// <value>The time format.</value>
        [DataMember(Name = "timeformet")]
        [JsonPropertyName("timeformat")]
        public TimeFormat TimeFormat { get; set; }

        /// <summary>
        /// Gets or sets the time-stamp of the last synchronisation of data with Chastikey
        /// </summary>
        /// <value>The time-stamp of the last synchronisation of data with Chastikey.</value>
        [DataMember(Name = "lastchastikeysync")]
        [JsonPropertyName("lastchastikeysync")]
        public int LastChastikeySync { get; set; }

        [DataMember(Name = "ageverificationsleft")]
        [JsonPropertyName("ageverificationsleft")]
        public int AgeVerificationsLeft { get; set; }

        /// <summary>
        /// Gets or sets the type of the account.
        /// </summary>
        /// <value>The type of the account.</value>
        [DataMember(Name = "accounttype")]
        [JsonPropertyName("accounttype")]
        public AccountType AccountType { get; set; }

        /// <summary>
        /// Gets or sets the main account identifier.
        /// </summary>
        /// <value>The main account identifier.</value>
        [DataMember(Name = "mainaccountid")]
        [JsonPropertyName("mainaccountid")]
        public string MainAccountId { get; set; }

        /// <summary>
        /// Gets or sets any accounts that list this as their main account.
        /// </summary>
        /// <value>The accounts.</value>
        [DataMember(Name = "accounts")]
        [JsonPropertyName("accounts")]
        public List<Account> Accounts { get; set; }
    }
}