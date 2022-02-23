using DotNet.TDD.DeskBooking.Domain.Entities;
using DotNet.TDD.DeskBooking.Domain.Exceptions;
using DotNet.TDD.DeskBooking.Domain.IPersistance;
using DotNet.TDD.DeskBooking.Infrastructure.Context;

namespace DotNet.TDD.DeskBooking.Infrastructure.Persistance
{
    public class EmployeePersistance : IEmployeePersistance
    {
        private readonly DeskBookingContext _dbContext;

        public EmployeePersistance(DeskBookingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public long Add(EmployeeEntity newEmployee)
        {
            if (FindByEmail(newEmployee.Email).Any())
                throw new DuplicateDataException($"An employee with email '{ newEmployee.Email }' already exists.");

            _dbContext.Employees.Add(newEmployee);
            _dbContext.SaveChanges();

            return newEmployee.Id;
        }

        public EmployeeEntity Delete(long id)
        {
            var deletedEmployee = Get(id);

            _dbContext.Employees.Remove(deletedEmployee);
            _dbContext.SaveChanges();

            return deletedEmployee;
        }

        public EmployeeEntity Get(long id)
        {
            var employee = _dbContext.Employees.Find(id);
            if (employee == null)
                throw new DataNotFoundException($"An employee with id '{ id }' doesn't exist.");

            return employee;
        }

        public IEnumerable<EmployeeEntity> GetAll()
        {
            return _dbContext.Employees.AsEnumerable();
        }

        private IEnumerable<EmployeeEntity> FindByEmail(string email)
        {
            return _dbContext.Employees
                .Where(employee => employee.Email == email)
                .AsEnumerable();
        }
    }
}