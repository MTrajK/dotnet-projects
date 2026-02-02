namespace DotNet.AIAgents.Samples.SimpleAIAgent.AIAgents
{
    using System;
    using System.Collections.Generic;

    using Azure;
    using Azure.AI.OpenAI;

    using DotNet.AIAgents.Samples.Common.Utils;

    using Microsoft.Agents.AI;

    using OpenAI.Chat;

    public class SimpleAIAgent
    {
        private AIAgent aiAgent;

        public SimpleAIAgent(ModelConfig modelConfig, AIAgentInfo aiAgentInfo)
        {
            this.aiAgent = this.CreateAiAgent(modelConfig, aiAgentInfo);
        }

        private AIAgent CreateAiAgent(ModelConfig modelConfig, AIAgentInfo aiAgentInfo)
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
                    instructions: aiAgentInfo.Instructions
                );

            return aiAgent;
        }

        public Task<AgentResponse> Run(string message)
        {
            return aiAgent.RunAsync(message);
        }

        public IAsyncEnumerable<AgentResponseUpdate> RunStreaming(string message)
        {
            return aiAgent.RunStreamingAsync(message);
        }
    }
}
