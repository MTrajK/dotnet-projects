using Endava.DotNetCommunity.Common.APIModels;

namespace Endava.DotNetCommunity.BLL.IService
{
    public interface ICreateUserService
    {
        public CreateUserResponseModel CreateUser(CreateUserRequestModel request);
    }
}
