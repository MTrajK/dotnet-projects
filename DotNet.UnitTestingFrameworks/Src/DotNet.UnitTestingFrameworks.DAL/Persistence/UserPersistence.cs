using DotNet.UnitTestingFrameworks.Common.Configuration;
using DotNet.UnitTestingFrameworks.Common.DomainModels;
using DotNet.UnitTestingFrameworks.DAL.IPersistence;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.IO;

namespace DotNet.UnitTestingFrameworks.DAL.Persistence
{
    public class UserPersistence : IUserPersistence
    {
        private IOptionsMonitor<FileStorageOptions> _fileStorageOptions;

        public UserPersistence(IOptionsMonitor<FileStorageOptions> fileStorageOptions)
        {
            _fileStorageOptions = fileStorageOptions;
        }

        public string CreateUser(UserModel user)
        {
            var fileName = GenerateFileName();

            using (StreamWriter writer = new StreamWriter(ConcatenateFilePath(fileName)))
            {
                string json = JsonConvert.SerializeObject(user);
                writer.Write(json);
            }

            return fileName;
        }

        public UserModel GetUser(string fileName)
        {
            UserModel user;

            using (StreamReader reader = new StreamReader(ConcatenateFilePath(fileName)))
            {
                string json = reader.ReadToEnd();
                user = JsonConvert.DeserializeObject<UserModel>(json);
            }

            return user;
        }

        private string ConcatenateFilePath(string fileName)
        {
            return string.Format("{0}//{1}", _fileStorageOptions.CurrentValue.FileStorageLocation, fileName);
        }

        private string GenerateFileName()
        {
            return string.Format("User_{0}.json", Guid.NewGuid().ToString());
        }
    }
}
