using DotNet.UnitTestingFrameworks.Common.DomainModels;

namespace DotNet.UnitTestingFrameworks.DAL.StorageAccess
{
    public interface IStorageWriter
    {
        string Write(UserModel user);
    }
}
