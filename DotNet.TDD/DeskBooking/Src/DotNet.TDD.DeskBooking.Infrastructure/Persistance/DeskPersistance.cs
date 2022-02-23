using DotNet.TDD.DeskBooking.Domain.IPersistance;

namespace DotNet.TDD.DeskBooking.Infrastructure.Persistance
{
    public class DeskPersistance : IDeskPersistance
    {
        public string CreateDesk(string name)
        {
            return "ID: " + name;
        }
    }
}
