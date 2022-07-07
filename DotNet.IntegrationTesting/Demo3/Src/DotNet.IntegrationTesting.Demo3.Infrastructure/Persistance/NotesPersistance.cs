namespace DotNet.IntegrationTesting.Demo3.Infrastructure.Persistance
{
    using DotNet.IntegrationTesting.Demo3.Domain.Entities;
    using DotNet.IntegrationTesting.Demo3.Domain.IPersistance;
    using DotNet.IntegrationTesting.Demo3.Infrastructure.Context;

    public class NotesPersistance : INotesPersistance
    {
        private readonly INotesContext _dbContext;

        public NotesPersistance(INotesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string GetNoteById(long noteId)
        {
            var note = _dbContext.Notes.Find(noteId);
            if (note == null)
                throw new Exception($"A note with id { noteId } doesn't exist.");

            return note.Note;
        }

        public long SaveNote(string note)
        {
            var newNote = new NoteEntity() { 
                Note = note 
            };

            _dbContext.Notes.Add(newNote);
            _dbContext.SaveContextChanges();

            return newNote.Id;
        }
    }
}
