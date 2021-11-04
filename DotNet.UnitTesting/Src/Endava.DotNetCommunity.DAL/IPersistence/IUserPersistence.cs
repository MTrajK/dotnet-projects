using Endava.DotNetCommunity.Common.DomainModels;

namespace Endava.DotNetCommunity.DAL.IPersistence
{
    public interface IUserPersistence
    {
        public string CreateUser(UserModel mdoel);

        public UserModel GetUser(string fileName);
    }
}
