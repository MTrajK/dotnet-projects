using Microsoft.VisualBasic;
using ModelContextProtocol.Server;
using System.ComponentModel;
using System.IO;

/// <summary>
/// Sample MCP tools for demonstration purposes.
/// These tools can be invoked by MCP clients to perform various operations.
/// </summary>
namespace DotNet.MCP.LocalFile.Tools
{
    public class LocalFileTools
    {
        private const string LocalDirectory = @"E:\Programming\GitHub\dotnet-projects\DotNet.MCP\LocalFileMCPServer\TestingDirectory"; // Change the directory using your local machine path

        [McpServerTool]
        [Description("Returns all the file names for a given pattern from the local machine.")]
        public List<string> SearchFilesWithPattern(
            [Description("Search pattern")] string searchPattern)
        {
            var fileNames = new List<string>();

            try
            {
                var filePaths = Directory.GetFiles(LocalDirectory, searchPattern);

                foreach (string filePath in filePaths)
                {
                    var fileName = Path.GetFileName(filePath);
                    fileNames.Add(fileName);
                }
            }
            catch { }

            return fileNames;
        }

        [McpServerTool]
        [Description("Returns the content of the wanted file if a file with that name exists on the local machine.")]
        public string GetFileWithName(
            [Description("File name")] string fileName)
        {
            var fileFullPath = Path.Combine(LocalDirectory, fileName);
            var fileContent = string.Empty;

            try
            {
                fileContent = File.ReadAllText(fileFullPath);
            }
            catch { }

            return fileContent;
        }

        [McpServerTool]
        [Description("Creates a file with the given name and fills it with the givent content on the local machine.")]
        public string CreateFileWithContent(
            [Description("File name")] string fileName,
            [Description("File content")] string fileContent)
        {
            var fileFullPath = Path.Combine(LocalDirectory, fileName);

            try
            {
                File.WriteAllText(fileFullPath, fileContent);
            }
            catch
            {
                return "Error: The file was not created";
            }

            return "Success: The file is created.";
        }
    }
}
