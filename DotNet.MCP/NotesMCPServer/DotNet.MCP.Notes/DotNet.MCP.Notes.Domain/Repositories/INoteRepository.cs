namespace DotNet.MCP.Notes.Domain.Repositories
{
    using DotNet.MCP.Notes.Domain.Entities;

    public interface INoteRepository
    {
        Task<IReadOnlyList<Note>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<Note?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<Note>> SearchAsync(string query, CancellationToken cancellationToken = default);

        Task<Note> CreateAsync(Note note, CancellationToken cancellationToken = default);

        Task UpdateAsync(Note note, CancellationToken cancellationToken = default);

        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
