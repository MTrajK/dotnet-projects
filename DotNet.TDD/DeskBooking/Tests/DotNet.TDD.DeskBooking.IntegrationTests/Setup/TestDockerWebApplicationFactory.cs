namespace DotNet.TDD.DeskBooking.IntegrationTests.Setup
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.AspNetCore.TestHost;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using DotNet.Testcontainers.Builders;
    using DotNet.Testcontainers.Containers;
    using DotNet.Testcontainers.Configurations;
    using Xunit;

    using DotNet.TDD.DeskBooking.Infrastructure.Context;

    public class TestDockerWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> 
        where TStartup : class
    {
        private const string _hostName = "dotnet.tdd.deskbooking.testdb";
        private const string _dbName = "TestDeskBooking";
        private const string _dbUsername = "sa";
        private const string _dbPassword = "TestDotNetTDD2022";
        private const string _dockerImage = "mcr.microsoft.com/mssql/server:2019-latest";

        private readonly TestcontainerDatabase _container;
     
        public TestDockerWebApplicationFactory()
        {
            _container = new TestcontainersBuilder<MsSqlTestcontainer>()
                .WithDatabase(new MsSqlTestcontainerConfiguration
                {
                    Password = _dbPassword,
                })
                .WithImage(_dockerImage)
                .WithName(_dbName)
                .WithHostname(_hostName)
                .Build();
            _container.StartAsync();
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
                services.AddDbContext<IDeskBookingContext, DeskBookingContext>(options => options.UseSqlServer(GetConnectionString())); ;
            });
        }

        private string GetConnectionString()
        {
            return $"Server={_hostName};Database={_dbName};User Id={_dbUsername};Password={_dbPassword};TrustServerCertificate=True;";
        }
    }
}
