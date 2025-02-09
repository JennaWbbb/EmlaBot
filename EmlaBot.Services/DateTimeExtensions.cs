using System;
using System.Collections.Generic;
using System.Text;

namespace EmlaBot.Services
{
    public static class DateTimeExtensions
    {
        public static int ToUnixTimestamp(this DateTime dateTime)
        {
            return (int)(dateTime - new DateTime(1970, 1, 1)).TotalSeconds;
        }
    }
}
