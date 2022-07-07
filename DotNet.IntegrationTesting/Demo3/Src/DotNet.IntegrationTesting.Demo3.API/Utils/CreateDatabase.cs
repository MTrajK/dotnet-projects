namespace DotNet.IntegrationTesting.Demo3.API.Utils
{
    using DotNet.IntegrationTesting.Demo3.Infrastructure.Configuration;
    using DotNet.IntegrationTesting.Demo3.Infrastructure.Context;

    public static class CreateDatabase
    {
        public static void CreateDbIfNotExists(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<NotesContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}
