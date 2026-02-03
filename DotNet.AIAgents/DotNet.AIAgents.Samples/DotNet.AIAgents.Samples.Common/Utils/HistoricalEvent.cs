namespace DotNet.AIAgents.Samples.Common.Utils
{
    public class HistoricalEvent
    {
        public string? Title { get; set; }

        public string? Date { get; set; }

        public string? Description { get; set; }

        public string? FactCheck { get; set; }

        public override string ToString()
        {
            return $"Title:\n{Title}\n\nDate:\n{Date}\n\nDescription:\n{Description}\n\nFactCheck:\n{FactCheck}";
        }
    }
}
