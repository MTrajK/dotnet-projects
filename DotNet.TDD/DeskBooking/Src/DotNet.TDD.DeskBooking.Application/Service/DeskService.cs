using DotNet.TDD.DeskBooking.Application.IService;
using DotNet.TDD.DeskBooking.Domain.IPersistance;

namespace DotNet.TDD.DeskBooking.Application.Service
{
    public class DeskService : IDeskService
    {
        private readonly IDeskPersistance _deskPersistance;

        public DeskService(IDeskPersistance deskPersistance)
        {
            _deskPersistance = deskPersistance;
        }

        public string CreateDesk(string name)
        {
            return _deskPersistance.CreateDesk(name);
        }
    }
}
