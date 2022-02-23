using DotNet.TDD.DeskBooking.Application.IService;
using DotNet.TDD.DeskBooking.Domain.DTOs.Requests;
using DotNet.TDD.DeskBooking.Domain.DTOs.Responses;
using DotNet.TDD.DeskBooking.Domain.Exceptions;
using DotNet.TDD.DeskBooking.Domain.IPersistance;
using DotNet.TDD.DeskBooking.Domain.Mappings;

namespace DotNet.TDD.DeskBooking.Application.Service
{
    public class BookingService : IBookingService
    {
        private readonly IBookingPersistance _bookingPersistance;
        private readonly IEmployeePersistance _employeePersistance;
        private readonly IDeskPersistance _deskPersistance;

        public BookingService(IBookingPersistance bookingPersistance, IEmployeePersistance employeePersistance, IDeskPersistance deskPersistance)
        {
            _bookingPersistance = bookingPersistance;
            _employeePersistance = employeePersistance;
            _deskPersistance = deskPersistance;
        }

        public long Add(BookingRequest request)
        {
            var bookingEntity = request.ToEntity();

            _employeePersistance.Get(bookingEntity.EmployeeId);

            var desk = _deskPersistance.Get(bookingEntity.DeskId);

            if (_bookingPersistance.CheckIfEmployeeHasBookingOnDate(bookingEntity.EmployeeId, bookingEntity.Date))
                throw new DuplicateDataException($"The employee has already a booking for { bookingEntity.Date.ToString("dd/MM/yyyy") }.");

            if (_bookingPersistance.NumberOfBookingsForDeskOnDate(bookingEntity.DeskId, bookingEntity.Date) == desk.Capacity)
                throw new DuplicateDataException("The desk's capacity is full.");

            return _bookingPersistance.Add(bookingEntity);
        }

        public BookingResponse Delete(long id)
        {
            return _bookingPersistance.Delete(id).ToResponse();
        }

        public BookingResponse Get(long id)
        {
            return _bookingPersistance.Get(id).ToResponse();
        }

        public IEnumerable<BookingResponse> GetAll()
        {
            return _bookingPersistance.GetAll().ToResponseList();
        }
    }
}
