using DotNet.TDD.DeskBooking.Domain.Entities;
using DotNet.TDD.DeskBooking.Domain.Exceptions;
using DotNet.TDD.DeskBooking.Domain.IPersistance;
using DotNet.TDD.DeskBooking.Infrastructure.Context;

namespace DotNet.TDD.DeskBooking.Infrastructure.Persistance
{
    public class BookingPersistance : IBookingPersistance
    {
        private readonly IDeskBookingContext _dbContext;

        public BookingPersistance(IDeskBookingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public long Add(BookingEntity newBooking)
        {
            _dbContext.Bookings.Add(newBooking);
            _dbContext.SaveContextChanges();

            return newBooking.Id;
        }

        public BookingEntity Delete(long id)
        {
            var deletedBooking = Get(id);

            _dbContext.Bookings.Remove(deletedBooking);
            _dbContext.SaveContextChanges();

            return deletedBooking;
        }

        public BookingEntity Get(long id)
        {
            var desk = _dbContext.Bookings.Find(id);
            if (desk == null)
                throw new DataNotFoundException($"A booking with id { id } doesn't exist.");

            return desk;
        }

        public IEnumerable<BookingEntity> GetAll()
        {
            return _dbContext.Bookings.AsEnumerable();
        }

        public bool CheckIfEmployeeHasBookingOnDate(long employeeId, DateTime date)
        {
            return _dbContext.Bookings
                .Where(booking => (booking.EmployeeId == employeeId) && booking.Date.Equals(date)).Any();
        }

        public int NumberOfBookingsForDeskOnDate(long deskId, DateTime date)
        {
            return _dbContext.Bookings
                .Where(booking => (booking.DeskId == deskId) && booking.Date.Equals(date)).Count();
        }
    }
}
