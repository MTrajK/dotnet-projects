using System.Text.RegularExpressions;

using Microsoft.Agents.AI.Workflows;

Func<string, string> lowercaseFunc = s => s.ToLower();
var lowercaseExecutor = lowercaseFunc.BindAsExecutor("LowercaseExecutor");

Func<string, string> reverseFunc = s => new string(s.Reverse().ToArray());
var reverseExecutor = reverseFunc.BindAsExecutor("ReverseExecutor");

Func<string, string> replaceFunc = s => Regex.Replace(s, @"[^a-zA-Z0-9\s]", "");
var replaceExecutor = replaceFunc.BindAsExecutor("ReplaceExecutor");


// Build the workflow by connecting executors sequentially
WorkflowBuilder builder = new(lowercaseExecutor);
builder.AddEdge(lowercaseExecutor, reverseExecutor)
    .WithOutputFrom(reverseExecutor);
builder.AddEdge(reverseExecutor, replaceExecutor)
    .WithOutputFrom(replaceExecutor);
var workflow = builder.Build();


// Execute the workflow with input data
Console.WriteLine("The Sequential Workflow is up. Try it.");
Console.WriteLine("______________________________________");
string message = "";
while ((message = Console.ReadLine()) != "exit")
{
    await using Run run = await InProcessExecution.RunAsync(workflow, message);
    foreach (WorkflowEvent evt in run.NewEvents)
    {
        switch (evt)
        {
            case ExecutorCompletedEvent executorComplete:
                Console.WriteLine($"{executorComplete.ExecutorId}: {executorComplete.Data}");
                break;
        }
    }
}
