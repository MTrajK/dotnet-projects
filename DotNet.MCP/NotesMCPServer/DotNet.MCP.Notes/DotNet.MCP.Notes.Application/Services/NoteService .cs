namespace DotNet.MCP.Notes.Application.Services
{
    using DotNet.MCP.Notes.Application.Utils;
    using DotNet.MCP.Notes.Domain.Repositories;
    using DotNet.MCP.Notes.Shared.DTOs;

    public class NoteService : INoteService
    {
        private readonly INoteRepository _repository;

        public NoteService(INoteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<NoteResponse>> GetAllAsync()
        {
            var notes = await _repository.GetAllAsync();
            return notes.Select(NoteMapping.ToResponse).ToList();
        }

        public async Task<NoteResponse?> GetByIdAsync(int id)
        {
            var note = await _repository.GetByIdAsync(id);
            return note?.ToResponse();
        }

        public async Task<IReadOnlyList<NoteResponse>> SearchAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return await GetAllAsync();
            }

            var notes = await _repository.SearchAsync(query);
            return notes.Select(NoteMapping.ToResponse).ToList();
        }

        public async Task<NoteResponse> CreateAsync(CreateNoteRequest request)
        {
            var note = request.ToEntity();
            var created = await _repository.CreateAsync(note);
            return created.ToResponse();
        }

        public async Task<bool> UpdateAsync(UpdateNoteRequest request)
        {
            var existing = await _repository.GetByIdAsync(request.Id);
            if (existing is null) {
                return false;
            }

            existing = request.ToEntity();
            await _repository.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing is null) {
                return false;
            }

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
