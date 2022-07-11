namespace DotNet.IntegrationTesting.Demo2.IntegrationTests.Setup
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.AspNetCore.TestHost;
    using Microsoft.Extensions.DependencyInjection;

    using DotNet.IntegrationTesting.Demo2.Application.IService;
    using DotNet.IntegrationTesting.Demo2.IntegrationTests.Stubs;

    public class TestWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                // Step 1: Remove the real CatFactsService dependency
                var serviceDescriptor = services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(ICatFactsService));
                services.Remove(serviceDescriptor);

                // Step 2: Add the stub CatFactsStubService dependency
                services.AddSingleton<ICatFactsService, CatFactsStubService>();
            });
        }
    }
}