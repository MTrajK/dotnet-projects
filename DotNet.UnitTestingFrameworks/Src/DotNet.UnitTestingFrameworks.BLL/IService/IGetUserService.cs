using DotNet.UnitTestingFrameworks.Common.APIModels;

namespace DotNet.UnitTestingFrameworks.BLL.IService
{
    public interface IGetUserService
    {
        public GetUserResponseModel GetUser(GetUserRequestModel request);
    }
}
