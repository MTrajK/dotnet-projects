namespace DotNet.AIAgents.Samples.Common.AIAgents
{
    using System;
    using System.ComponentModel;

    using Azure;
    using Azure.AI.OpenAI;

    using DotNet.AIAgents.Samples.Common.Utils;

    using Microsoft.Agents.AI;
    using Microsoft.Extensions.AI;

    using ModelContextProtocol.Client;

    using OpenAI.Chat;
    using OpenAI.Responses;

    public class ToolsAIAgent
    {
        private AIAgent? aiAgent;

        public ToolsAIAgent(ModelConfig modelConfig, AIAgentInfo aiAgentInfo)
        {
            this.aiAgent = this.CreateAIAgent(modelConfig, aiAgentInfo);
        }

        public AIAgent CreateAIAgent(ModelConfig modelConfig, AIAgentInfo aiAgentInfo)
        {
            // Connect to the remote model (Azure deployed LLM)
            AzureOpenAIClient azureClient = new AzureOpenAIClient(
                new Uri(modelConfig.ApiEndpoint),
                new AzureKeyCredential(modelConfig.ApiKey));
            ChatClient chatClient = azureClient.GetChatClient(modelConfig.Name);

            // Create an Agent using the LLM as brain
            AIAgent aiAgent = chatClient
                .AsAIAgent(
                    name: aiAgentInfo.Name,
                    instructions: aiAgentInfo.Instructions,
                    tools: [AIFunctionFactory.Create(GetTimeZone)]
                );

            return aiAgent;
        }

        [Description("Get the local time zone.")]
        private static string GetTimeZone()
        {
            var timeZone = TimeZoneInfo.Local;

            return timeZone.Id;
        }

        private async Task<IList<AITool>> GetMCPTools()
        {
            // Get MCP Tools
            await using var mcpClient = await McpClient.CreateAsync(new StdioClientTransport(new()
            {
                Name = "MCPServer",
                Command = "uvx",
                Arguments = ["mcp-server-time", "-local-timezone=America/New_York"],
            }));

            var mcpTools = await mcpClient.ListToolsAsync().ConfigureAwait(false);

            return [..mcpTools];
        }

        public Task<AgentResponse> Run(string message)
        {
            return aiAgent.RunAsync(message);
        }
    }
}
