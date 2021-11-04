using System;
namespace Endava.DotNetCommunity.Common.Exceptions
{
    public class MissingStrategyException : Exception
    {
        public MissingStrategyException() : base() { }

        public MissingStrategyException(string message) : base(message) { }
    }
}
