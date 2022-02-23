using DotNet.TDD.DeskBooking.Domain.Entities;

namespace DotNet.TDD.DeskBooking.Domain.IPersistance
{
    public interface IEmployeePersistance
    {
        public long Add(EmployeeEntity newEmployee);
        public EmployeeEntity Delete(long id);
        public EmployeeEntity Get(long id);
        public IEnumerable<EmployeeEntity> GetAll();
    }
}
