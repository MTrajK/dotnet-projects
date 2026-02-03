namespace DotNet.AIAgents.Samples.Common.AIAgents
{
    using System;
    using System.Collections.Generic;

    using Azure;
    using Azure.AI.OpenAI;

    using DotNet.AIAgents.Samples.Common.Utils;

    using Microsoft.Agents.AI;
    using Microsoft.Extensions.AI;

    using OpenAI.Chat;

    public class RagAIAgent
    {
        public readonly AIAgent AIAgent;

        public RagAIAgent(ModelConfig modelConfig, AIAgentInfo aiAgentInfo)
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

            // Define the mock RAG search
            ChatOptions chatOptions = new()
            {
                Instructions = aiAgentInfo.Instructions
            };
            TextSearchProviderOptions textSearchOptions = new()
            {
                SearchTime = TextSearchProviderOptions.TextSearchBehavior.BeforeAIInvoke
            };
            Func<ChatClientAgentOptions.AIContextProviderFactoryContext, CancellationToken, ValueTask<AIContextProvider>> ragMock =
                (ctx, ct) => new ValueTask<AIContextProvider>(new TextSearchProvider(MockSearchAsync, ctx.SerializedState, ctx.JsonSerializerOptions, textSearchOptions));

            // Create an Agent using the LLM as brain
            AIAgent aiAgent = chatClient
                .AsAIAgent(new ChatClientAgentOptions()
                    {
                        Name = aiAgentInfo.Name,
                        ChatOptions = chatOptions,
                        AIContextProviderFactory = ragMock
                    }
                );

            return aiAgent;
        }

        static Task<IEnumerable<TextSearchProvider.TextSearchResult>> MockSearchAsync(string query, CancellationToken cancellationToken)
        {
            // The mock search inspects the user's question and returns pre-defined snippets
            // that resemble documents stored in an external knowledge source.
            List<TextSearchProvider.TextSearchResult> results = [];

            if (query.Contains("return", StringComparison.OrdinalIgnoreCase) || query.Contains("refund", StringComparison.OrdinalIgnoreCase))
            {
                results.Add(new()
                {
                    SourceName = "Contoso Outdoors Return Policy",
                    SourceLink = "https://contoso.com/policies/returns",
                    Text = "Customers may return any item within 30 days of delivery. Items should be unused and include original packaging. Refunds are issued to the original payment method within 5 business days of inspection."
                });
            }

            if (query.Contains("shipping", StringComparison.OrdinalIgnoreCase))
            {
                results.Add(new()
                {
                    SourceName = "Contoso Outdoors Shipping Guide",
                    SourceLink = "https://contoso.com/help/shipping",
                    Text = "Standard shipping is free on orders over $50 and typically arrives in 3-5 business days within the continental United States. Expedited options are available at checkout."
                });
            }

            if (query.Contains("tent", StringComparison.OrdinalIgnoreCase) || query.Contains("fabric", StringComparison.OrdinalIgnoreCase))
            {
                results.Add(new()
                {
                    SourceName = "TrailRunner Tent Care Instructions",
                    SourceLink = "https://contoso.com/manuals/trailrunner-tent",
                    Text = "Clean the tent fabric with lukewarm water and a non-detergent soap. Allow it to air dry completely before storage and avoid prolonged UV exposure to extend the lifespan of the waterproof coating."
                });
            }

            return Task.FromResult<IEnumerable<TextSearchProvider.TextSearchResult>>(results);
        }

        public Task<AgentResponse> Run(string message)
        {
            return AIAgent.RunAsync(message);
        }
    }
}
