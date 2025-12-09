namespace DotNet.MCP.Notes.Infrastructure.Repositories
{
    using DotNet.MCP.Notes.Domain.Entities;
    using DotNet.MCP.Notes.Domain.Repositories;
    using DotNet.MCP.Notes.Infrastructure.Persistence;

    using Microsoft.EntityFrameworkCore;

    public class NoteRepository : INoteRepository
    {
        private readonly NotesDbContext _context;

        public NoteRepository(NotesDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Note>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Notes
                .OrderByDescending(note => note.Id)
                .ToListAsync(cancellationToken);
        }

        public async Task<Note?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Notes.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<IReadOnlyList<Note>> SearchAsync(string query, CancellationToken cancellationToken = default)
        {
            query = query.Trim();

            return await _context.Notes
                .Where(note => 
                        (note.Title != null && note.Title.Contains(query)) ||
                        (note.Description != null && note.Description.Contains(query)))
                .OrderByDescending(note => note.Id)
                .ToListAsync(cancellationToken);
        }

        public async Task<Note> CreateAsync(Note note, CancellationToken cancellationToken = default)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync(cancellationToken);
            return note;
        }

        public async Task UpdateAsync(Note note, CancellationToken cancellationToken = default)
        {
            _context.Notes.Update(note);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var note = await _context.Notes.FindAsync(new object[] { id }, cancellationToken);
            if (note is null) {
                return;
            }

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
