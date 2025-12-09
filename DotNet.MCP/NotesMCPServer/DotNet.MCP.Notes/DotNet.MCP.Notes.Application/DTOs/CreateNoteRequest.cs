namespace DotNet.MCP.Notes.Application.DTOs
{
    public class CreateNoteRequest
    {
        public required string Title { get; set; }

        public string? Description { get; set; }
    }
}
