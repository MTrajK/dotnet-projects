using System;

namespace Endava.DotNetCommunity.Common.Exceptions
{
    public class NotFoundOperationException : Exception
    {
        public NotFoundOperationException() : base() { }

        public NotFoundOperationException(string message) : base(message) { } 
    }
}
