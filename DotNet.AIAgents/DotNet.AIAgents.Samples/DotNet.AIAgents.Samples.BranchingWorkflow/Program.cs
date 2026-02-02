using System.Text.RegularExpressions;

using Microsoft.Agents.AI.Workflows;


Func<string, string> lowercaseFunc = s => s.ToLower();
var lowercaseExecutor = lowercaseFunc.BindAsExecutor("LowercaseExecutor");

Func<string, string> uppercaseFunc = s => s.Replace("upper", "UPPER");
var uppercaseExecutor = uppercaseFunc.BindAsExecutor("UpperExecutor");

Func<string, string> reverseFunc = s => new string(s.Reverse().ToArray());
var reverseExecutor = reverseFunc.BindAsExecutor("ReverseExecutor");

Func<string, string> replaceFunc = s => Regex.Replace(s, @"[^a-zA-Z0-9\s]", "");
var replaceExecutor = replaceFunc.BindAsExecutor("ReplaceExecutor");


Func<string, bool> GetCondition(bool expectedResult) =>
    s => s.Contains("upper") == expectedResult;


// Build the workflow by connecting executors conditionally
var workflow = new WorkflowBuilder(lowercaseExecutor)
    .AddEdge(lowercaseExecutor, uppercaseExecutor, condition: GetCondition(true))
    .AddEdge(uppercaseExecutor, reverseExecutor)
    .AddEdge(lowercaseExecutor, reverseExecutor, condition: GetCondition(false))
    .AddEdge(reverseExecutor, replaceExecutor)
    .WithOutputFrom(replaceExecutor)
    .Build();


// Execute the workflow with input data - Try with "Hello, World!" and "Hello, Upper World!"
Console.WriteLine("The Conditional Workflow is up. Try it.");
Console.WriteLine("_______________________________________");
string message = "";
while ((message = Console.ReadLine()) != "exit")
{
    await using Run run = await InProcessExecution.RunAsync(workflow, message);

    foreach (WorkflowEvent evt in run.NewEvents)
    {
        switch (evt)
        {
            case ExecutorCompletedEvent executorComplete:
                Console.WriteLine($"Step - {executorComplete.ExecutorId}: {executorComplete.Data}");
                break;
            case WorkflowOutputEvent outputEvent:
                Console.WriteLine($"FINAL OUTPUT: {outputEvent.Data}");
                break;
        }
    }
}
