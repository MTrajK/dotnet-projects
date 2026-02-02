using DotNet.AIAgents.Samples.Common.AIAgents;
using DotNet.AIAgents.Samples.Common.Utils;

ModelConfig modelConfig = GetModelConfig.Get();
AIAgentInfo aiAgentInfo = new()
{
    Name = "Time Assistant",
    Instructions = "You are a local machine time assistant."
};

ToolsAIAgent toolsAIAgent = new(modelConfig, aiAgentInfo);


Console.WriteLine("The Tools AI Agent is up. Try it.");
Console.WriteLine("___________________________");
string message = "";
while ((message = Console.ReadLine()) != "exit")
{
    Console.WriteLine(await toolsAIAgent.Run(message));
    Console.WriteLine();
}