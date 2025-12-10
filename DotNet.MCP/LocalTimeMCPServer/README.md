# Local Time MCP Server

## Step by step adding Local Time MCP Server into Claude Desktop

1. Open the Claude Desktop Configuration File
   * Open **Claude Desktop**.
   * Click on the **Developer** tab in the settings menu (***Menu ☰** -> **File** -> **Settings..***).
   * Click the **Edit Config** button to open the ***claude_desktop_config.json*** file in your default text editor. The file is located at:
      - Windows: **%APPDATA%\Claude\claude_desktop_config.json**
      - macOS: **~/Library/Application Support/Claude/claude_desktop_config.json**

2. Add Your .NET Server Configuration
   * Add an entry for your server within the mcpServers object in the JSON file. You can configure it to run directly using the dotnet run command.\
   Add the following configuration, replacing the path with the absolute path to your .csproj file.

   ```json
   {
      "mcpServers": {
         "local-time-server": {
            "command": "dotnet",
            "args": [
            "run",
            "--project",
            "E:\\\\Programming\\\\GitHub\\\\dotnet-projects\\\\DotNet.MCP\\\\LocalTimeMCPServer\\\\DotNet.MCP.LocalTime\\\\DotNet.MCP.LocalTime\\\\DotNet.MCP.LocalTime.csproj",
            "--no-build"
            ]
         }
      }
   }
   ```

3. Save the Configuration File and Restart Claude Desktop
   * Save the ***claude_desktop_config.json*** file.
   * Completely quit and restart the Claude Desktop application for the changes to take effect.

4. Verify the Server Connection
   * After restarting, look for a **search and tools** in the bottom-left part of the conversation input box.
   * Click the icon to view the list of available MCP tools. Your .NET server's tools should be listed there.
   * You can now ask Claude to use the tools provided by your server. You may need to grant permissions the first time you use a new tool.
