using Endava.DotNetCommunity.Common.APIModels;

namespace Endava.DotNetCommunity.BLL.IService
{
    public interface IGetUserService
    {
        public GetUserResponseModel GetUser(GetUserRequestModel request);
    }
}
