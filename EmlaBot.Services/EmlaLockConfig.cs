using System;
using System.Diagnostics.CodeAnalysis;

namespace EmlaBot.Services
{
    public class EmlaLockConfig : IEmlaLockConfig
    {
        [SuppressMessage("Minor Code Smell", "S1075:URIs should not be hardcoded", Justification = "This is a default implementation for use with dependency injection - if you need to override to point at a different implementation, implement IEmlaLockConfig on a different class")]
        public Uri BaseUrl { get; } = new Uri("https://api.emlalock.com/");
    }
}