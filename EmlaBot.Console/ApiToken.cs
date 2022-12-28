using EmlaBot.Models;

namespace EmlaBot.Console
{
    public class ApiToken : IApiToken
    {
        public string? UserId { get; set; }

        public string? ApiKey { get; set; }
    }
}