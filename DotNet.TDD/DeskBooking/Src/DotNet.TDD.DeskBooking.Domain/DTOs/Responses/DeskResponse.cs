namespace DotNet.TDD.DeskBooking.Domain.DTOs.Responses
{
    public class DeskResponse
    {
        public long Id { get; set; }
        public int Floor { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
    }
}
