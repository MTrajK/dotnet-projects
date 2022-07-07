namespace DotNet.IntegrationTesting.Demo3.Domain.IPersistance
{
    public interface INotesPersistance
    {
        public string GetNoteById(long noteId);

        public long SaveNote(string note);
    }
}
