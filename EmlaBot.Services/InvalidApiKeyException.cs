using System;
using System.Net.Http;

namespace EmlaBot.Services
{
    [Serializable]
    public class InvalidApiKeyException : HttpRequestException
    {
        public InvalidApiKeyException()
        {
        }

        public InvalidApiKeyException(string message) : base(message)
        {
        }

        public InvalidApiKeyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}