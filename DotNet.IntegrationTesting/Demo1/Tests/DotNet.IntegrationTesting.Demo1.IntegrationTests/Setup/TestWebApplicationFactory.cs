namespace DotNet.IntegrationTesting.Demo1.IntegrationTests.Setup
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.AspNetCore.TestHost;

    public class TestWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                // Nothing to be done here, no dependency from external artifacts 
            });
        }
    }
}
