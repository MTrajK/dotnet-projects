namespace DotNet.UnitTestingFrameworks.Common.Configuration
{
    public class FileStorageOptions
    {
        public const string FileStorageSettingsSection = "DotNet.UnitTestingFrameworks:FileStorageSettings";

        public string FileStorageLocation { get; set; }
    }
}
