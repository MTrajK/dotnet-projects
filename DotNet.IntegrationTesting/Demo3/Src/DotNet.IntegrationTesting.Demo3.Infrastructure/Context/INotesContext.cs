namespace DotNet.IntegrationTesting.Demo3.Infrastructure.Context
{
    using Microsoft.EntityFrameworkCore;

    using DotNet.IntegrationTesting.Demo3.Domain.Entities;

    public interface INotesContext
    {
        public DbSet<NoteEntity> Notes { get; set; }

        public int SaveContextChanges();
    }
}
