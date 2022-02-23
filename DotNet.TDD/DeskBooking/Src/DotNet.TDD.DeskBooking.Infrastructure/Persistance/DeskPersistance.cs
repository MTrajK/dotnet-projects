using DotNet.TDD.DeskBooking.Domain.Entities;
using DotNet.TDD.DeskBooking.Domain.Exceptions;
using DotNet.TDD.DeskBooking.Domain.IPersistance;
using DotNet.TDD.DeskBooking.Infrastructure.Context;

namespace DotNet.TDD.DeskBooking.Infrastructure.Persistance
{
    public class DeskPersistance : IDeskPersistance
    {
        private readonly DeskBookingContext _dbContext;

        public DeskPersistance(DeskBookingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public long Add(DeskEntity newDesk)
        {
            if (FindByLevelAndNumber(newDesk.Floor, newDesk.Number).Any())
                throw new DuplicateDataException($"A desk with number '{ newDesk.Number }' on floor '{ newDesk.Floor }' already exists.");

            _dbContext.Desks.Add(newDesk);
            _dbContext.SaveChanges();

            return newDesk.Id;
        }

        public DeskEntity Delete(long id)
        {
            var deletedDesk = Get(id);

            _dbContext.Desks.Remove(deletedDesk);
            _dbContext.SaveChanges();

            return deletedDesk;
        }

        public DeskEntity Get(long id)
        {
            var desk = _dbContext.Desks.Find(id);
            if (desk == null)
                throw new DataNotFoundException($"A desk with id '{ id }' doesn't exists.");

            return desk;
        }

        public IEnumerable<DeskEntity> GetAll()
        {
            return _dbContext.Desks.AsEnumerable();
        }

        private IEnumerable<DeskEntity> FindByLevelAndNumber(int floor, int number)
        {
            return _dbContext.Desks
                .Where(desk => (desk.Floor == floor) && (desk.Number == number))
                .AsEnumerable();
        }
    }
}
