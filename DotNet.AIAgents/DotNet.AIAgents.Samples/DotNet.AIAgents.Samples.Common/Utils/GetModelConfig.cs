namespace DotNet.AIAgents.Samples.Common.Utils
{
    using System;

    public static class GetModelConfig
    {
        public static ModelConfig Get()
        {
            string hardcodedApiEndpoint = string.Empty; // Add the Azure OpenAI Endpoint here if you don't want to store in the env variable
            string hardcodedApiKey = string.Empty; // Add the Azure OpenAI ApiKey here if you don't want to store in the env variable

            string apiEndpoint = string.IsNullOrWhiteSpace(hardcodedApiEndpoint) ?
                Environment.GetEnvironmentVariable("AZURE_OPENAI_APIENDPOINT") ?? throw new InvalidOperationException("AZURE_OPENAI_APIENDPOINT is not set.") :
                hardcodedApiKey;
            string apiKey = string.IsNullOrWhiteSpace(hardcodedApiKey) ?
                Environment.GetEnvironmentVariable("AZURE_OPENAI_APIKEY") ?? throw new InvalidOperationException("AZURE_OPENAI_APIKEY is not set.") :
                hardcodedApiKey;
            string modelName = "gpt-5-chat";

            return new ModelConfig
            {
                ApiEndpoint = apiEndpoint,
                ApiKey = apiKey,
                Name = modelName
            };
        }
    }
}
