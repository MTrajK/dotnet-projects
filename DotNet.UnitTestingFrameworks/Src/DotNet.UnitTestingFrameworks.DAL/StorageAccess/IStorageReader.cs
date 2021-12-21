using DotNet.UnitTestingFrameworks.Common.DomainModels;

namespace DotNet.UnitTestingFrameworks.DAL.StorageAccess
{
    public interface IStorageReader
    {
        UserModel Read(string id);
    }
}
