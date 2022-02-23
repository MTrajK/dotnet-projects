using DotNet.TDD.DeskBooking.Application.IService;
using DotNet.TDD.DeskBooking.Domain.DTOs.Requests;
using DotNet.TDD.DeskBooking.Domain.DTOs.Responses;
using DotNet.TDD.DeskBooking.Domain.IPersistance;
using DotNet.TDD.DeskBooking.Domain.Mappings;

namespace DotNet.TDD.DeskBooking.Application.Service
{
    public class DeskService : IDeskService
    {
        private readonly IDeskPersistance _deskPersistance;

        public DeskService(IDeskPersistance deskPersistance)
        {
            _deskPersistance = deskPersistance;
        }

        public long Add(DeskRequest request)
        {
            return _deskPersistance.Add(request.ToEntity());
        }

        public DeskResponse Delete(long id)
        {
            return _deskPersistance.Delete(id).ToResponse();
        }

        public DeskResponse Get(long id)
        {
            return _deskPersistance.Get(id).ToResponse();
        }

        public IEnumerable<DeskResponse> GetAll()
        {
            return _deskPersistance.GetAll().ToResponseList();
        }
    }
}
