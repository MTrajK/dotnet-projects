namespace DotNet.IntegrationTesting.Demo1.IntegrationTests.Setup
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;

    public class TestWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Nothing to be done here, no dependency from external artifacts 
            });
        }
    }
}
