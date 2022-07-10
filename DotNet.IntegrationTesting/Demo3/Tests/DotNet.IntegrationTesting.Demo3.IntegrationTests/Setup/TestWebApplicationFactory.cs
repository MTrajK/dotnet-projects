namespace DotNet.IntegrationTesting.Demo3.IntegrationTests.Setup
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using DotNet.IntegrationTesting.Demo3.Infrastructure.Context;

    public class TestWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Step 1: Remove the existing NotesContext which is using a real DB
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<NotesContext>));

                services.Remove(descriptor);

                // Step 2: Add new NotesContext with in-memory DB
                services.AddDbContext<INotesContext, NotesContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });
            });
        }
    }
}
