namespace DotNet.IntegrationTesting.Demo3.Application.IService
{
    public interface INotesService
    {
        public string GetNoteById(long noteId);

        public long SaveNote(string note);
    }
}
