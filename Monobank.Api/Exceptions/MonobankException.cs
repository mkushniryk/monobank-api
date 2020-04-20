using System;

namespace Sentinelab.Monobank.Api.Exceptions
{
    public class MonobankException : Exception
    {
        public MonobankException(string message) : base(message)
        {
        }
    }
}
