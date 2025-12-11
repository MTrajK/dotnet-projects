namespace DotNet.MCP.Notes.Application.Services
{
    using DotNet.MCP.Notes.Shared.DTOs;

    public interface INoteService
    {
        Task<IReadOnlyList<NoteResponse>> GetAllAsync();

        Task<NoteResponse?> GetByIdAsync(int id);

        Task<IReadOnlyList<NoteResponse>> SearchAsync(string query);

        Task<NoteResponse> CreateAsync(CreateNoteRequest request);

        Task<bool> UpdateAsync(UpdateNoteRequest request);

        Task<bool> DeleteAsync(int id);
    }
}
