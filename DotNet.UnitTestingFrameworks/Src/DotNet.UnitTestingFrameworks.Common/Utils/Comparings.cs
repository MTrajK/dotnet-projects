using DotNet.UnitTestingFrameworks.Common.APIModels;
using DotNet.UnitTestingFrameworks.Common.DomainModels;

namespace DotNet.UnitTestingFrameworks.Common.Utils
{
    public static class Comparings
    {
        public static bool DeepCompare(this UserModel a, UserModel b)
        {
            return (a.FirstName == b.FirstName) &&
                (a.LastName == b.LastName) &&
                (a.Email == b.Email) &&
                (a.Number1 == b.Number1) &&
                (a.Number2 == b.Number2) &&
                (a.Operation == b.Operation);
        }

        public static bool DeepCompare(this CreateUserResponseModel a, CreateUserResponseModel b)
        {
            return a.FileName == b.FileName;
        }
    }
}
