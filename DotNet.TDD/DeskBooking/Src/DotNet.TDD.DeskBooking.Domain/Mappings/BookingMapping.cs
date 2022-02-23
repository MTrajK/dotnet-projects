using DotNet.TDD.DeskBooking.Domain.DTOs.Requests;
using DotNet.TDD.DeskBooking.Domain.DTOs.Responses;
using DotNet.TDD.DeskBooking.Domain.Entities;

namespace DotNet.TDD.DeskBooking.Domain.Mappings
{
    public static class BookingMapping
    {
        public static BookingEntity ToEntity(this BookingRequest request)
        {
            return new BookingEntity()
            {
                DeskId = request.DeskId,
                EmployeeId = request.EmployeeId,
                Date = request.Date.Date // Takes only the date, without time
            };
        }

        public static BookingResponse ToResponse(this BookingEntity entity)
        {
            return new BookingResponse()
            {
                Id = entity.Id,
                DeskId = entity.DeskId,
                EmployeeId = entity.EmployeeId,
                Date = entity.Date
            };
        }

        public static IEnumerable<BookingResponse> ToResponseList(this IEnumerable<BookingEntity> entities)
        {
            return entities.Select(entity => entity.ToResponse());
        }
    }
}
