# Notes App

## Architecture
Clean architecture: Web APP, Web API, Application, Domain, Infrastructure.
Also there is a Shared project, these are shared model between different apps, like Notes MCP server and Notes App (API, Blazor, MCP).

## Launch
Use the .slnLaunch file in VS - 2 project are needed to be run (the API and the Web APP that is using the API)

## Database
EnsureDatabaseCreated is just for demo. This is not a good practice for PROD.
With this function the database is created if it's missing for the demo purpose.

## URLs
API: https://localhost:7001\
Blazor: https://localhost:7100

## Endpoints
Postman collection: Notes.postman_collection.json
   * Get All Notes: GET /api/notes
   * Get Single Note: GET /api/notes/{id}
   * Search Notes: GET /api/notes/search?querry={querry}
   * Create Note: POST /api/notes
   * Update Note: PUT /api/notes
   * Delete Note: DELETE /api/notes/{id}

# Notes App MCP Server

## Step by step adding Notes App MCP Server into Claude Desktop

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
         "notes-app-mcp-server": {
            "command": "dotnet",
            "args": [
            "run",
            "--project",
            "E:\\\\Programming\\\\GitHub\\\\dotnet-projects\\\\DotNet.MCP\\\\NotesMCPServer\\\\DotNet.MCP.Notes\\\\DotNet.MCP.Notes.MCPServer\\\\DotNet.MCP.Notes.MCPServer.csproj", // Change the path using your local machine path.
            "--no-build"
            ]
         }
      }
   }
   ```

3. Save the Configuration File and Restart Claude Desktop
   * Save the ***claude_desktop_config.json*** file.
   * Completely quit and restart the Claude Desktop application for the changes to take effect (not just by clicking X on the app, right click and Quit on the Claude Desktop icon from the Notification area).

4. Verify the Server Connection
   * After restarting, look for a **search and tools** in the bottom-left part of the conversation input box.
   * Click the icon to view the list of available MCP tools. Your .NET server's tools should be listed there (wait several seconds if it' not here, Claude Desktop needs time to build & run the MCP server using the provided command).
   * You can now ask Claude to use the tools provided by your server. You may need to grant permissions the first time you use a new tool.
