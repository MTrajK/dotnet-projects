namespace DotNet.AIAgents.Samples.Common.AIAgents
{
    using System;
    using System.Text.Json;

    using Azure;
    using Azure.AI.OpenAI;

    using DotNet.AIAgents.Samples.Common.Utils;

    using Microsoft.Agents.AI;
    using Microsoft.Extensions.AI;

    using OpenAI.Chat;

    using ChatResponseFormat = Microsoft.Extensions.AI.ChatResponseFormat;

    public class StructuredOutputAIAgent<T>
    {
        public readonly AIAgent AIAgent;

        public StructuredOutputAIAgent(ModelConfig modelConfig, AIAgentInfo aiAgentInfo)
        {
            this.AIAgent = CreateAIAgent(modelConfig, aiAgentInfo);
        }

        private static AIAgent CreateAIAgent(ModelConfig modelConfig, AIAgentInfo aiAgentInfo)
        {
            // Connect to the remote model (Azure deployed LLM)
            AzureOpenAIClient azureClient = new AzureOpenAIClient(
                new Uri(modelConfig.ApiEndpoint),
                new AzureKeyCredential(modelConfig.ApiKey));
            ChatClient chatClient = azureClient.GetChatClient(modelConfig.Name);

            // Define the structured output schema
            JsonElement schema = AIJsonUtilities.CreateJsonSchema(typeof(T));
            ChatOptions chatOptions = new()
            {
                ResponseFormat = ChatResponseFormat.ForJsonSchema(
                    schema: schema,
                    schemaName: aiAgentInfo.Name,
                    schemaDescription: aiAgentInfo.SchemaDescription
                ),
                Instructions = aiAgentInfo.Instructions
            };

            // Create an Agent using the LLM as brain
            AIAgent aiAgent = chatClient
                .AsAIAgent(new ChatClientAgentOptions()
                    {
                        Name = aiAgentInfo.Name,
                        ChatOptions = chatOptions
                    }
                );

            return aiAgent;
        }

        public Task<AgentResponse> Run(string message)
        {
            return AIAgent.RunAsync(message);
        }

        public T Deserialize(AgentResponse response)
        {
            return response.Deserialize<T>(JsonSerializerOptions.Web);
        }
    }
}
