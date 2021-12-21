using DotNet.UnitTestingFrameworks.Common.DomainModels;
using DotNet.UnitTestingFrameworks.DAL.IPersistence;
using DotNet.UnitTestingFrameworks.DAL.StorageAccess;

namespace DotNet.UnitTestingFrameworks.DAL.Persistence
{
    public class UserPersistence : IUserPersistence
    {
        private IStorageWriter _storageWriter;
        private IStorageReader _storageReader;

        public UserPersistence(IStorageWriter storageWriter, IStorageReader storageReader)
        {
            _storageWriter = storageWriter;
            _storageReader = storageReader;
        }

        public string CreateUser(UserModel user)
        {
            return _storageWriter.Write(user);
        }

        public UserModel GetUser(string id)
        {
            return _storageReader.Read(id);
        }
    }
}
