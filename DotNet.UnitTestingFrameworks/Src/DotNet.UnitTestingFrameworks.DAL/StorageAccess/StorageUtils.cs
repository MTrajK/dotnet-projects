using System;

namespace DotNet.UnitTestingFrameworks.DAL.StorageAccess
{
    public static class StorageUtils
    {
        public static string ConcatenateFilePath(string fileName, string fileStorageLocation)
        {
            return string.Format("{0}//{1}", fileName, fileStorageLocation);
        }

        public static string GenerateFileName()
        {
            return string.Format("User_{0}.json", Guid.NewGuid().ToString());
        }
    }
}
