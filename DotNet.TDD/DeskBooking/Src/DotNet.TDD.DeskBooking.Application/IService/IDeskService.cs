using DotNet.TDD.DeskBooking.Domain.DTOs.Requests;
using DotNet.TDD.DeskBooking.Domain.DTOs.Responses;

namespace DotNet.TDD.DeskBooking.Application.IService
{
    public interface IDeskService
    {
        public long Add(DeskRequest request);
        public DeskResponse Delete(long id);
        public DeskResponse Get(long id);
        public IEnumerable<DeskResponse> GetAll();
    }
}
