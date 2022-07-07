namespace DotNet.IntegrationTesting.Demo3.Infrastructure.Configuration
{
    using DotNet.IntegrationTesting.Demo3.Infrastructure.Context;

    public static class DbInitializer
    {
        public static void Initialize(NotesContext context)
        {
            // Just in case if the DB isn't created with the existing migrations
            context.Database.EnsureCreated();
        }
    }
}
