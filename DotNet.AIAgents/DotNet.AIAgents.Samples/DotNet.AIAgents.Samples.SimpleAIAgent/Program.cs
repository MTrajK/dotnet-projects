using DotNet.AIAgents.Samples.Common.AIAgents;
using DotNet.AIAgents.Samples.Common.Utils;

ModelConfig modelConfig = GetModelConfig.Get();
AIAgentInfo aiAgentInfo = new()
{
    Name = "Joker",
    Instructions =
@"You are a joke teller.
Detect the subject the client want to hear a joke about (if no specific subject, you choose it).
Tell only the joke and nothing else.
Don't ask questions.
The joke must be short (no more than 30 words)."
};

SimpleAIAgent aiAgent = new(modelConfig, aiAgentInfo);


Console.WriteLine("The Simple AI Agent is up. Try it.");
Console.WriteLine("___________________________");
string message = "";
while ((message = Console.ReadLine()) != "exit")
{
    Console.WriteLine(await aiAgent.Run(message));
    Console.WriteLine();
}


Console.WriteLine("Try the Simple AI Agent with streaming response.");
Console.WriteLine("_________________________________________");
while ((message = Console.ReadLine()) != "exit")
{
    await foreach (var update in aiAgent.RunStreaming(message))
    {
        Console.WriteLine(update);
    }
    Console.WriteLine();
}