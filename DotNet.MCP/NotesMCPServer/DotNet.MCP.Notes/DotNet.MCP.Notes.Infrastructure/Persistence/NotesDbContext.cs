namespace DotNet.MCP.Notes.Infrastructure.Persistence
{
    using DotNet.MCP.Notes.Domain.Entities;

    using Microsoft.EntityFrameworkCore;

    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options)
        {
        }

        public DbSet<Note> Notes => Set<Note>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>(builder =>
            {
                builder.ToTable("Notes");
                builder.HasKey(n => n.Id);
                builder.Property(n => n.Title)
                       .IsRequired()
                       .HasMaxLength(200);
                builder.Property(n => n.Description)
                       .HasMaxLength(int.MaxValue);
            });
        }
    }
}
