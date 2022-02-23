using DotNet.TDD.DeskBooking.Domain.DTOs.Requests;
using DotNet.TDD.DeskBooking.Domain.DTOs.Responses;

namespace DotNet.TDD.DeskBooking.Application.IService
{
    public interface IBookingService
    {
        public long Add(BookingRequest request);
        public BookingResponse Delete(long id);
        public BookingResponse Get(long id);
        public IEnumerable<BookingResponse> GetAll();
    }
}
