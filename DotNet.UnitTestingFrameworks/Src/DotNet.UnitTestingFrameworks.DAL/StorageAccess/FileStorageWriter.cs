using System.IO;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using DotNet.UnitTestingFrameworks.Common.DomainModels;
using DotNet.UnitTestingFrameworks.Common.Configuration;

namespace DotNet.UnitTestingFrameworks.DAL.StorageAccess
{
    public class FileStorageWriter : IStorageWriter
    {
        private IOptionsMonitor<FileStorageOptions> _fileStorageOptions;

        public FileStorageWriter(IOptionsMonitor<FileStorageOptions> fileStorageOptions)
        {
            _fileStorageOptions = fileStorageOptions;
        }

        public string Write(UserModel user)
        {
            var fileName = StorageUtils.GenerateFileName();
            var filePath = StorageUtils.ConcatenateFilePath(_fileStorageOptions.CurrentValue.FileStorageLocation, fileName);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                string json = JsonConvert.SerializeObject(user);
                writer.Write(json);
            }

            return fileName;
        }
    }
}
