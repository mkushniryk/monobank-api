using System;

namespace Monobank.Api.Client.Exceptions
{
    public class MonobankException : Exception
    {
        public MonobankException(string message) : base(message)
        {
        }
    }
}
