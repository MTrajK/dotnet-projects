using System;

namespace DotNet.UnitTestingFrameworks.Common.Exceptions
{
    public class MissingStrategyException : Exception
    {
        public MissingStrategyException() : base() { }

        public MissingStrategyException(string message) : base(message) { }
    }
}
