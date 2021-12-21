using System.IO;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using DotNet.UnitTestingFrameworks.Common.DomainModels;
using DotNet.UnitTestingFrameworks.Common.Configuration;

namespace DotNet.UnitTestingFrameworks.DAL.StorageAccess
{
    public class FileStorageReader : IStorageReader
    {
        private IOptionsMonitor<FileStorageOptions> _fileStorageOptions;

        public FileStorageReader(IOptionsMonitor<FileStorageOptions> fileStorageOptions)
        {
            _fileStorageOptions = fileStorageOptions;
        }

        public UserModel Read(string fileName)
        {
            var filePath = StorageUtils.ConcatenateFilePath(fileName, _fileStorageOptions.CurrentValue.FileStorageLocation);
            UserModel user;

            using (StreamReader reader = new StreamReader(filePath))
            {
                string json = reader.ReadToEnd();
                user = JsonConvert.DeserializeObject<UserModel>(json);
            }

            return user;
        }
    }
}
