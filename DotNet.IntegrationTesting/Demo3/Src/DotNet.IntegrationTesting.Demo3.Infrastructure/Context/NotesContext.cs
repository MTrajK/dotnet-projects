namespace DotNet.IntegrationTesting.Demo3.Infrastructure.Context
{
    using Microsoft.EntityFrameworkCore;

    using DotNet.IntegrationTesting.Demo3.Domain.Entities;

    public class NotesContext : DbContext, INotesContext
    {
        public DbSet<NoteEntity> Notes { get; set; }

        public NotesContext(DbContextOptions<NotesContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // No need from Fluent API mapping! 
            // The tables are already created using the properties from EmployeeEntity, DeskEntity and BookingEntity.
            // Id is taken as primary key everywhere, in BookingEntity DeskId and EmployeeId are taken as foreign keys.
            // Only seed some DB data here if you need.
        }

        public int SaveContextChanges()
        {
            return SaveChanges();
        }
    }
}
