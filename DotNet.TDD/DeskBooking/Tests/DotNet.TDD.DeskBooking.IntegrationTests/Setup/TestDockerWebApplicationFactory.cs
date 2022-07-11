using DotNet.TDD.DeskBooking.Infrastructure.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DotNet.TDD.DeskBooking.IntegrationTests.Setup
{
    public class TestDockerWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup>, IAsyncLifetime
        where TStartup : class
    {
        private readonly MsSqlTestContainer _testContainer;

        public TestDockerWebApplicationFactory()
        {
            _testContainer = new MsSqlTestContainer();
        }

        public async Task InitializeAsync()
        {
            await _testContainer.InitializeAsync();
        }

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

                // Step 2: Add new DeskBookingContext with Docker database connection string
                services.AddDbContext<IDeskBookingContext, DeskBookingContext>(
                    options => options.UseSqlServer(
                        _testContainer.GetConnectionString(),
                        /*
                         * When trying to create the DB in the app workflow, everything is okay (it's created from first try).
                         * But from here, something is wrong. Maybe the Docker isn't done with setup? 
                         * (getting Error: 18456, Severity: 14, State: 38. from MsSql Server).
                         */
                        sqlOptions => sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 10,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null
                        )
                    )
                );
            });
        }

        public async Task DisposeAsync()
        {
            await _testContainer.DisposeAsync();
        }
    }
}
