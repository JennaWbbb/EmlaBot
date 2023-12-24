using System;
using System.Net.Http;

namespace EmlaBot.Services
{
    [Serializable]
    public class RateLimitedException : HttpRequestException
    {
        public RateLimitedException()
        {
        }

        public RateLimitedException(string message) : base(message)
        {
        }

        public RateLimitedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}