namespace DotNet.TDD.DeskBooking.IntegrationTests.Setup
{
    using System.Linq;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.AspNetCore.TestHost;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using DotNet.TDD.DeskBooking.Infrastructure.Context;

    public class TestInMemoryWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            /*
             * Note: ConfigureTestServices instead of ConfigureServices.
             * For SUTs that still use the Web Host, the test app's builder.ConfigureServices callback
             * is executed before the SUT's Startup.ConfigureServices code.
             * The test app's builder.ConfigureTestServices callback is executed after.
             */
            builder.ConfigureTestServices(services =>
            {
                // Step 1: Remove the existing DeskBookingContext which is using a real DB
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<DeskBookingContext>));

                services.Remove(descriptor);

                // Step 2: Add new DeskBookingContext with in-memory DB
                services.AddDbContext<IDeskBookingContext, DeskBookingContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });
            });
        }
    }
}
