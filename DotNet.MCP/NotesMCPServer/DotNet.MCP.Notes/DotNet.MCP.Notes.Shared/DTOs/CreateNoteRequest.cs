namespace DotNet.MCP.Notes.Shared.DTOs
{
    public class CreateNoteRequest
    {
        public required string Title { get; set; }

        public string? Description { get; set; }
    }
}
