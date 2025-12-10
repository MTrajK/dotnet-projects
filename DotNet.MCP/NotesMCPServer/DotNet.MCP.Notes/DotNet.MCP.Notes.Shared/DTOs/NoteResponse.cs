namespace DotNet.MCP.Notes.Shared.DTOs
{
    public class NoteResponse
    {
        public required int Id { get; set; }

        public required string Title { get; set; }

        public string? Description { get; set; }
    }
}
