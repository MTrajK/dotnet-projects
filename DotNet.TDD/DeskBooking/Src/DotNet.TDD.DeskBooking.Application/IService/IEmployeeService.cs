using DotNet.TDD.DeskBooking.Domain.DTOs.Requests;
using DotNet.TDD.DeskBooking.Domain.DTOs.Responses;

namespace DotNet.TDD.DeskBooking.Application.IService
{
    public interface IEmployeeService
    {
        public long Add(EmployeeRequest request);
        public EmployeeResponse Delete(long id);
        public EmployeeResponse Get(long id);
        public IEnumerable<EmployeeResponse> GetAll();
    }
}
