using DotNet.TDD.DeskBooking.Application.IService;
using DotNet.TDD.DeskBooking.Domain.IPersistance;

namespace DotNet.TDD.DeskBooking.Application.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeePersistance _employeePersistance;

        public EmployeeService(IEmployeePersistance employeePersistance)
        {
            _employeePersistance = employeePersistance;
        }

        public string CreateEmployee(string name)
        {
            return _employeePersistance.CreateEmployee(name);
        }
    }
}
