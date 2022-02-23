namespace DotNet.TDD.DeskBooking.Domain.DTOs.Responses
{
    public class BookingResponse
    {
        public long Id { get; set; }
        public long DeskId { get; set; }
        public long EmployeeId { get; set; }
        public DateTime Date { get; set; }
    }
}
