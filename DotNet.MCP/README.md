# .NET MCP
.NET demos (with a presentation) that explain using MCP servers from MCP clients (Claude Desktop) and how to create a MCP server using .NET.

## Project structure
- [Docs](https://github.com/MTrajK/dotnet-projects/tree/main/DotNet.MCP/Docs) - PowerPoint presentation and some notes.
- [LocalTimeMCPServer](https://github.com/MTrajK/dotnet-projects/tree/main/DotNet.MCP/LocalTimeMCPServer) - Simple MCP server written in .NET that reads the local machine time.
- [LocalFileMCPServer](https://github.com/MTrajK/dotnet-projects/tree/main/DotNet.MCP/LocalFileMCPServer) - Simple MCP server written in .NET that reads some local file and edit the same.
- [NotesMCPServer](https://github.com/MTrajK/dotnet-projects/tree/main/DotNet.MCP/NotesMCPServer) - Simple MCP server written in .NET that uses API from the Notes Web APP and controls the application.

## Used techs and things:
- .NET
- Web API
- Blazor
- Entity Framework
- Microsoft.Extensions.AI.Templates

## Requirements
- Visual Studio (2026 for best experience)

## Create a .NET MCP server

Step by step

1. Install Microsoft.Extensions.AI.Templates
https://learn.microsoft.com/en-us/dotnet/ai/quickstarts/build-mcp-server
Use cmd/powershell - "dotnet new install Microsoft.Extensions.AI.Templates"

2. Create MCP Server project
From visual studio project creation search for: "mcpserver" or "Local MCP Server Console App"
or use cmd/powershell - "dotnet new mcpserver -n SampleMcpServer"

3. Open the .csproj file and edit the <PackageId> tag with unique name.
Open .mcp/server.json and edit the packages/identifier with the same unique name.
Example: "MCPTest1"

4. Configure the MCP clients json config:
```json
{
  "mcpServers": {
      "your-MCP-server-unique-name": {
        "command": "dotnet",        // This is the command line command that will be run - for node.js server: "node", "npx", for python server: "uv", "uvx", "python" 
        "args": [
        "run",
        "--project",
        "C:\\\\Path\\\\To\\\\Your\\\\project.csproj",  // This is the location, file - the root of the project that will need to be executed
        "--no-build"
        ]
      }
  }
}
```
