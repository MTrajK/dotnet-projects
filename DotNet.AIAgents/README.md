# .NET AI Agents
What are AI Agents? AI Agents history and .NET demos (with a presentation) that explain AI Agents and AI Workflow using Microsoft Agent Framework (.NET MAF).

## Project structure
- [Docs](https://github.com/MTrajK/dotnet-projects/tree/main/DotNet.AIAgents/Docs) - PowerPoint presentation and some notes.
- [DotNet.AIAgents.Samples](https://github.com/MTrajK/dotnet-projects/tree/main/DotNet.AIAgents/DotNet.AIAgents.Samples) - All the demos.

## Used techs and things
- [.NET 8.0 SDK or later](https://dotnet.microsoft.com/download) (.NET 10 preferred)
- dotnet cli
- Visual Studio (Visual Studio 2026 for best experience)
- Microsoft.Agents.AI
- Azure.AI.OpenAI

## NuGets needed
AI NuGet packages installation (in the DotNet.AIAgents.Samples.Common - all the AI Agents logic is there):
```powershell
dotnet add package Microsoft.Agents.AI --prerelease
dotnet add package Azure.AI.OpenAI --prerelease
dotnet add package Microsoft.Agents.AI.OpenAI --prerelease
dotnet add package ModelContextProtocol --prerelease
```

## Env variables setup
Save API keys (per machine):
```powershell
setx AZURE_OPENAI_APIENDPOINT "value"
setx AZURE_OPENAI_APIKEY "value"
```
***Note**: Before using the env variables -> restart powershell/terminal, Visual Studio. So they will be able to read the values form the registry.*

Read the API key:
```powershell
$Env:AZURE_OPENAI_APIKEY
#or
Get-ChildItem Env:AZURE_OPENAI_APIKEY
```

## MCP uvx run
In one of the demos we have a MCP server call.\
That MCP will be run using UVX command. So we need to have UVX installed:
```powershell
winget install astral-sh.uv
```
***Note**: Before using the uvx or uv commands -> restart powershell/terminal, Visual Studio. So they will be able to detect the newly installed commands.*

MCP: https://mcp.so/server/time/modelcontextprotocol
```json
{
  "mcpServers": {
    "time": {
      "command": "uvx",
      "args": [
        "mcp-server-time",
        "--local-timezone=America/New_York"
      ]
    }
  }
}
```