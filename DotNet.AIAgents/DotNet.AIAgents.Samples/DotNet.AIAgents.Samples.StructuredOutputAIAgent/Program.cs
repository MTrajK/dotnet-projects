using DotNet.AIAgents.Samples.Common.AIAgents;
using DotNet.AIAgents.Samples.Common.Utils;

ModelConfig modelConfig = GetModelConfig.Get();
AIAgentInfo agentInfo = new()
{
    Name = "CompanyInfo",
    Instructions =
@"You're an experienced company investigator.
For a given company as an input you provide 5 fields: Name, Industry, Founded, IsPublic, and StockSymbol.",
    SchemaDescription =
@"Information about a company including the name,
industry where the company operates, 
the date when the company was founded,
if the company is public or private,
and stock symbol if the company is publicly traded."
};

StructuredOutputAIAgent<CompanyInfo> structuredOutputAIAgent = new(modelConfig, agentInfo);


Console.WriteLine("The Structured Output AI Agent is up. Try it.");
Console.WriteLine("___________________________");
string message = "";
while ((message = Console.ReadLine()) != "exit")
{
    var response = await structuredOutputAIAgent.Run(message);
    var structuredResponse = response.Deserialize<CompanyInfo>();
    Console.WriteLine(structuredResponse.ToString());
    Console.WriteLine();
}