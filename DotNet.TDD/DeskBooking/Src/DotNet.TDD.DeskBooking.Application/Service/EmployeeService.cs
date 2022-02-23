using DotNet.TDD.DeskBooking.Application.IService;
using DotNet.TDD.DeskBooking.Domain.DTOs.Requests;
using DotNet.TDD.DeskBooking.Domain.DTOs.Responses;
using DotNet.TDD.DeskBooking.Domain.IPersistance;
using DotNet.TDD.DeskBooking.Domain.Mappings;

namespace DotNet.TDD.DeskBooking.Application.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeePersistance _employeePersistance;

        public EmployeeService(IEmployeePersistance employeePersistance)
        {
            _employeePersistance = employeePersistance;
        }

        public long Add(EmployeeRequest request)    
        {
            return _employeePersistance.Add(request.ToEntity());
        }

        public EmployeeResponse Delete(long id)
        {
            return _employeePersistance.Delete(id).ToResponse();
        }

        public EmployeeResponse Get(long id)
        {
            return _employeePersistance.Get(id).ToResponse();
        }

        public IEnumerable<EmployeeResponse> GetAll()
        {
            return _employeePersistance.GetAll().ToResponseList();
        }
    }
}
