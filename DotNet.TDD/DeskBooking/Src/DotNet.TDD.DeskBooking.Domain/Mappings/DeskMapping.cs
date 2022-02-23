using DotNet.TDD.DeskBooking.Domain.DTOs.Requests;
using DotNet.TDD.DeskBooking.Domain.DTOs.Responses;
using DotNet.TDD.DeskBooking.Domain.Entities;

namespace DotNet.TDD.DeskBooking.Domain.Mappings
{
    public static class DeskMapping
    {
        public static DeskEntity ToEntity(this DeskRequest request)
        {
            return new DeskEntity()
            {
                Floor = request.Floor,
                Number = request.Number,
                Capacity = request.Capacity
            };
        }

        public static DeskResponse ToResponse(this DeskEntity entity)
        {
            return new DeskResponse()
            {
                Id = entity.Id,
                Floor = entity.Floor,
                Number = entity.Number,
                Capacity = entity.Capacity
            };
        }

        public static IEnumerable<DeskResponse> ToResponseList(this IEnumerable<DeskEntity> entities)
        {
            return entities.Select(entity => new DeskResponse()
            {
                Id = entity.Id,
                Floor = entity.Floor,
                Number = entity.Number,
                Capacity = entity.Capacity
            });
        }
    }
}
