using DotNet.TDD.DeskBooking.Domain.Entities;

namespace DotNet.TDD.DeskBooking.Domain.IPersistance
{
    public interface IBookingPersistance
    {
        public long Add(BookingEntity newDesk);
        public BookingEntity Delete(long id);
        public BookingEntity Get(long id);
        public IEnumerable<BookingEntity> GetAll();
        public bool CheckIfEmployeeHasBookingOnDate(long employeeId, DateTime date);
        public int NumberOfBookingsForDeskOnDate(long deskId, DateTime date);
    }
}
