namespace DotNet.IntegrationTesting.Demo3.Application.Service
{
    using DotNet.IntegrationTesting.Demo3.Application.IService;
    using DotNet.IntegrationTesting.Demo3.Domain.IPersistance;

    public class NotesService : INotesService
    {
        private readonly INotesPersistance _notesPersistance;

        public NotesService(INotesPersistance notesPersistance)
        {
            _notesPersistance = notesPersistance;
        }

        public string GetNoteById(long noteId)
        {
            return _notesPersistance.GetNoteById(noteId);
        }

        public long SaveNote(string note)
        {
            return _notesPersistance.SaveNote(note);
        }
    }
}
