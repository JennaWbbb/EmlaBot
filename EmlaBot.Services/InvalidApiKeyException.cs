using System;
using System.Net.Http;

namespace EmlaBot.Services
{
    [Serializable]
    internal class InvalidApiKeyException : HttpRequestException
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