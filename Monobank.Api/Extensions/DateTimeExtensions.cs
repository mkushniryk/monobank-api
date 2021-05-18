using System;

namespace Monobank.Api.Client.Extensions
{
    public static class DateTimeExtensions
    {
        public static long ToUnixSeconds(this DateTime date)
        {
            return (long)date.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }
    }
}
