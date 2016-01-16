using System;

namespace WalkaChomika.Models
{
    internal class NoManaException : Exception
    {
        public NoManaException()
        {
        }

        public NoManaException(string message) : base(message)
        {
        }

        public NoManaException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

}