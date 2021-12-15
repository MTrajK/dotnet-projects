using DotNet.UnitTestingFrameworks.BLL.IService;
using DotNet.UnitTestingFrameworks.Common.APIModels;
using DotNet.UnitTestingFrameworks.Common.Utils;
using DotNet.UnitTestingFrameworks.DAL.IPersistence;

namespace DotNet.UnitTestingFrameworks.BLL.Service
{
    public class GetUserService : IGetUserService
    {
        private IUserPersistence _persistance;

        public GetUserService(IUserPersistence persistance)
        {
            _persistance = persistance;
        }

        public GetUserResponseModel GetUser(GetUserRequestModel request)
        {
            var user = _persistance.GetUser(request.FileName);

            return user.ToApiModel();
        }
    }
}
