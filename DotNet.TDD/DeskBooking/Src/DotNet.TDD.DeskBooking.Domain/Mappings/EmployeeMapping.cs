using DotNet.TDD.DeskBooking.Domain.DTOs.Requests;
using DotNet.TDD.DeskBooking.Domain.DTOs.Responses;
using DotNet.TDD.DeskBooking.Domain.Entities;

namespace DotNet.TDD.DeskBooking.Domain.Mappings
{
    public static class EmployeeMapping
    {
        public static EmployeeEntity ToEntity(this EmployeeRequest request)
        {
            return new EmployeeEntity()
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName
            };
        }

        public static EmployeeResponse ToResponse(this EmployeeEntity entity)
        {
            return new EmployeeResponse()
            {
                Id = entity.Id,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName
            };
        }

        public static IEnumerable<EmployeeResponse> ToResponseList(this IEnumerable<EmployeeEntity> entities)
        {
            return entities.Select(entity => new EmployeeResponse()
            {
                Id = entity.Id,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName
            });
        }
    }
}
