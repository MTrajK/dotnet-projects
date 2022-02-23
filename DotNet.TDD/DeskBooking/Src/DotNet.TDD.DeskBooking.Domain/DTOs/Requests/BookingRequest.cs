namespace DotNet.TDD.DeskBooking.Domain.DTOs.Requests
{
    public class BookingRequest
    {
        public long DeskId { get; set; }
        public long EmployeeId { get; set; }
        public DateTime Date { get; set; }
    }
}
