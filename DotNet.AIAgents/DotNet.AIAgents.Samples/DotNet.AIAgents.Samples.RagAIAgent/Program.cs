using DotNet.AIAgents.Samples.Common.AIAgents;
using DotNet.AIAgents.Samples.Common.Utils;

ModelConfig modelConfig = GetModelConfig.Get();
AIAgentInfo agentInfo = new()
{
    Name = "Shop Assistant",
    Instructions = "You're contoso shop assistant."
};

RagAIAgent ragAIAgent = new(modelConfig, agentInfo);


Console.WriteLine("The RAG AI Agent is up. Try it.");
Console.WriteLine("___________________________");
string message = "";
while ((message = Console.ReadLine()) != "exit")
{
    Console.WriteLine(await ragAIAgent.Run(message));
    Console.WriteLine();
}