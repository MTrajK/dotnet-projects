namespace DotNet.TDD.DeskBooking.Domain.Exceptions
{
    public class DuplicateDataException : Exception
    {
        public DuplicateDataException() : base()
        {
        }

        public DuplicateDataException(string? message) : base(message)
        {
        }
    }
}
