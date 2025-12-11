namespace DotNet.MCP.Notes.Application.Utils
{
    using DotNet.MCP.Notes.Domain.Entities;
    using DotNet.MCP.Notes.Shared.DTOs;

    public static class NoteMapping
    {
        public static Note ToEntity(this CreateNoteRequest request)
        {
            return new Note()
            {
                Title = request.Title,
                Description = request.Description
            };
        }

        public static Note ToEntity(this UpdateNoteRequest request)
        {
            return new Note()
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description
            };
        }

        public static NoteResponse ToResponse(this Note entity)
        {
            return new NoteResponse()
            {
                Id = (int)entity!.Id,
                Title = entity!.Title,
                Description = entity.Description
            };
        }
    }
}
