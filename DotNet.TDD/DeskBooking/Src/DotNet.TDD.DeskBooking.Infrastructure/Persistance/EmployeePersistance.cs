using DotNet.TDD.DeskBooking.Domain.IPersistance;

namespace DotNet.TDD.DeskBooking.Infrastructure.Persistance
{
    public class EmployeePersistance : IEmployeePersistance
    {
        public string CreateEmployee(string name)
        {
            return "ID: " + name;
        }
    }
}
