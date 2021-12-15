using DotNet.UnitTestingFrameworks.Common.APIModels;

namespace DotNet.UnitTestingFrameworks.BLL.IService
{
    public interface ICreateUserService
    {
        public CreateUserResponseModel CreateUser(CreateUserRequestModel request);
    }
}
