namespace DotNet.MCP.Notes.Infrastructure
{
    using DotNet.MCP.Notes.Domain.Repositories;
    using DotNet.MCP.Notes.Infrastructure.Persistence;
    using DotNet.MCP.Notes.Infrastructure.Repositories;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("NotesDb");

            services.AddDbContext<NotesDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<INoteRepository, NoteRepository>();

            return services;
        }

        public static IServiceProvider EnsureDatabaseCreated(this IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<NotesDbContext>();
                db.Database.EnsureCreated(); // Just for a DEMO (bad idea for a PROD app)
            }

            return services;
        }
    }
}
