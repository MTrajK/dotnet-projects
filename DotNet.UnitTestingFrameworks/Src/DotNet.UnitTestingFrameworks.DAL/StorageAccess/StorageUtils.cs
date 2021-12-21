using System;

namespace DotNet.UnitTestingFrameworks.DAL.StorageAccess
{
    public static class StorageUtils
    {
        public static string ConcatenateFilePath(string fileStorageLocation, string fileName)
        {
            return string.Format("{0}//{1}", fileStorageLocation, fileName);
        }

        public static string GenerateFileName()
        {
            return string.Format("User_{0}.json", Guid.NewGuid().ToString());
        }
    }
}
