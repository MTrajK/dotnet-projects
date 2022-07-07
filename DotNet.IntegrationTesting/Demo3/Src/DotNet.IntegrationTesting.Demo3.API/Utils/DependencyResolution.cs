namespace DotNet.IntegrationTesting.Demo3.API.Utils
{
    using Microsoft.EntityFrameworkCore;

    using DotNet.IntegrationTesting.Demo3.Application.IService;
    using DotNet.IntegrationTesting.Demo3.Application.Service;
    using DotNet.IntegrationTesting.Demo3.Domain.IPersistance;
    using DotNet.IntegrationTesting.Demo3.Infrastructure.Context;
    using DotNet.IntegrationTesting.Demo3.Infrastructure.Persistance;

    public static class DependencyResolution
    {
        public static void AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<INotesContext, NotesContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("NotesDB")));
        }

        public static void AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<INotesPersistance, NotesPersistance>();
        }

        public static void AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddTransient<INotesService, NotesService>();
        }
    }
}
