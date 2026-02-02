using DotNet.AIAgents.Samples.Common.AIAgents;
using DotNet.AIAgents.Samples.Common.Utils;

ModelConfig modelConfig = GetModelConfig.Get();
AIAgentInfo agentInfo = new()
{
    Name = "Assistant",
    Instructions = "You are a helpful assistant."
};

SimpleAIAgent simpleAIAgent = new(modelConfig, agentInfo);


Console.WriteLine("The Simple AI Agent is up. Try it.");
Console.WriteLine("__________________________________");
string message = "";
while ((message = Console.ReadLine()) != "exit")
{
    Console.WriteLine(await simpleAIAgent.Run(message));
    Console.WriteLine();
}



SessionAIAgent sessionAIAgent = new(modelConfig, agentInfo);
var session = await sessionAIAgent.GetNewSession();


Console.WriteLine("The Session AI Agent is up. Try it.");
Console.WriteLine("___________________________________");
message = "";
while ((message = Console.ReadLine()) != "exit")
{
    Console.WriteLine(await sessionAIAgent.Run(message, session));
    Console.WriteLine();
}