using DotNet.TDD.DeskBooking.Domain.Entities;

namespace DotNet.TDD.DeskBooking.Domain.IPersistance
{
    public interface IDeskPersistance
    {
        public long Add(DeskEntity newDesk);
        public DeskEntity Delete(long id);
        public DeskEntity Get(long id);
        public IEnumerable<DeskEntity> GetAll();
    }
}
