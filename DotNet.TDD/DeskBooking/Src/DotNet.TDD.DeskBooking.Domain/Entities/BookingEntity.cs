namespace DotNet.TDD.DeskBooking.Domain.Entities
{
    public class BookingEntity : BaseEntity
    {
        public long DeskId { get; set; }
        public long EmployeeId { get; set; }
        public DateTime Date { get; set; }

        public DeskEntity Desk { get; set; }
        public EmployeeEntity Employee { get; set; }
    }
}
