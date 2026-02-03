using DotNet.AIAgents.Samples.Common.AIAgents;
using DotNet.AIAgents.Samples.Common.Utils;

using Microsoft.Agents.AI.Workflows;

ModelConfig modelConfig = GetModelConfig.Get();


AIAgentInfo historianAIAgentInfo = new()
{
    Name = "Historian",
    Instructions =
@"You are a historian.
You have an access to the current date (in date format: dd MM).
Detect the region from the message and find the biggest historic event in the last 100 years in that region that happend on the current date.
Explain that event in less than 100 words.
If no region detected return empty response.
Use the following format for the response when the region is detected.
Title:
Write the event title here
Date:
Write the full date in this format dd MM yyyy here
Description:
Write the event description here"
};
ToolsAIAgent historianAIAgent = new(modelConfig, historianAIAgentInfo);


AIAgentInfo translatorAIAgentInfo = new()
{
    Name = "Translator",
    Instructions =
@"You are a translator.
You are able to translate only in one direction, from English to Italian.
Just translate the English text into Italian and nothing else.
If the detected languange is not English return empty response."
};
SimpleAIAgent translatorAIAgent = new(modelConfig, translatorAIAgentInfo);


AIAgentInfo factCheckerAIAgentInfo = new()
{
    Name = "HistoricalFactChecker",
    Instructions =
@"You're an experienced bilingual (English & Italian) historical fact-checker.
You will recieve a Italian text composed of 3 parts: Title of the event, Date of the event (format: dd MM yyyy), and the Description of the event.
Fact check all these 3 sections and append your opinion as 4th section in English, that 4th section will contains the findings from the fact-checking.
Leave the other 2 sections (title, description) untouched in Italian.
The fact-check section should have less than 100 words.",
    SchemaDescription =
@"Information about a historical event including:
the title of the event in Italian,
the date when the event happened (format: dd MM yyyy),
the description of the event in Italian,
and the historical event fact-check in English."
};
StructuredOutputAIAgent<HistoricalEvent> factCheckerAIAgent = new(modelConfig, factCheckerAIAgentInfo);


// Build the workflow by connecting executors sequentially
var workflow = new WorkflowBuilder(historianAIAgent.AIAgent)
    .AddEdge(historianAIAgent.AIAgent, translatorAIAgent.AIAgent)
    .AddEdge(translatorAIAgent.AIAgent, factCheckerAIAgent.AIAgent)
    .WithOutputFrom(factCheckerAIAgent.AIAgent)
    .Build();




Dictionary<string, string> results = new Dictionary<string, string>();
Console.WriteLine("The Workflow of Historian & Translator & Structured AI Agents is up. Try it.");
Console.WriteLine("____________________________________________________________________________");
string message = "";
while ((message = Console.ReadLine()) != "exit")
{
    StreamingRun run = await InProcessExecution.StreamAsync(workflow, message);
    await run.TrySendMessageAsync(new TurnToken(emitEvents: true));

    await foreach (WorkflowEvent evt in run.WatchStreamAsync().ConfigureAwait(false))
    {
        if (evt is AgentResponseUpdateEvent executorComplete)
        {   
            if (results.ContainsKey(executorComplete.ExecutorId))
            {
                results[executorComplete.ExecutorId] += executorComplete.Data.ToString();
            }
            else
            {
                results.Add(executorComplete.ExecutorId, executorComplete.Data.ToString());
            }
            Console.WriteLine($"{executorComplete.ExecutorId}: {executorComplete.Data}");
        }
    }

    Console.WriteLine("___________________________________________");
    Console.WriteLine("___________________________________________");

    foreach (var key in results.Keys)
    {
        Console.WriteLine($"AI Agent: {key}\n\nResult:\n{results[key]}");
        Console.WriteLine("___________________________________________");
        Console.WriteLine("___________________________________________");
    }
}