using Endava.DotNetCommunity.BLL.IService;
using Endava.DotNetCommunity.Common.APIModels;
using Endava.DotNetCommunity.Common.Utils;
using Endava.DotNetCommunity.DAL.IPersistence;

namespace Endava.DotNetCommunity.BLL.Service
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
