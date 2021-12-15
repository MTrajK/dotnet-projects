using DotNet.UnitTestingFrameworks.Common.APIModels;
using DotNet.UnitTestingFrameworks.Common.DomainModels;

namespace DotNet.UnitTestingFrameworks.Common.Utils
{
    public static class Mappings
    {
        public static UserModel ToDomainModel(this CreateUserRequestModel model, int result)
        {
            return new UserModel(
                model.FirstName,
                model.LastName,
                model.Email,
                model.Number1,
                model.Number2,
                model.Operation,
                result);
        }

        public static GetUserResponseModel ToApiModel(this UserModel model)
        {
            return new GetUserResponseModel(
                model.FirstName,
                model.LastName,
                model.Email,
                model.Number1,
                model.Number2,
                model.Operation,
                model.Result);
        }
    }
}
