using DotNet.UnitTestingFrameworks.Common.DomainModels;

namespace DotNet.UnitTestingFrameworks.DAL.IPersistence
{
    public interface IUserPersistence
    {
        public string CreateUser(UserModel mdoel);

        public UserModel GetUser(string fileName);
    }
}
