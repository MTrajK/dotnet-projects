using System.ComponentModel;
using ModelContextProtocol.Server;

/// <summary>
/// Sample MCP tools for demonstration purposes.
/// These tools can be invoked by MCP clients to perform various operations.
/// </summary>
namespace DotNet.MCP.LocalTime.Tools
{
    public class LocalTimeTools
    {
        [McpServerTool]
        [Description("Returns the current time from the user's local machine using the wanted time format.")]
        public string GetLocalTime(
            [Description("Time format")] string timeFormat = "HH:mm:ss")
        {
            var currentTime = DateTime.Now;
            var currentTimeToString = currentTime.ToString(timeFormat);

            return currentTimeToString;
        }

        [McpServerTool]
        [Description("Returns the time zone from the user's local machine.")]
        public string GetLocalTimeZone()
        {
            var localTimeZone = TimeZoneInfo.Local;

            return localTimeZone.Id;
        }
    }
}
