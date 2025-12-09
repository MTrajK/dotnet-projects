namespace DotNet.MCP.Notes.Application.DTOs
{
    public class UpdateNoteRequest
    {
        public required int Id { get; set; }

        public required string Title { get; set; }

        public string? Description { get; set; }
    }
}
