namespace DotNet.MCP.Notes.Application
{
    using DotNet.MCP.Notes.Application.Services;

    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<INoteService, NoteService>();
            return services;
        }
    }
}
