namespace DotNet.IntegrationTesting.Demo2.API
{
    using DotNet.IntegrationTesting.Demo2.Application.IService;
    using DotNet.IntegrationTesting.Demo2.Application.Service;

    public static class DependencyResolution
    {
        public static void AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddSingleton<HttpClient>();
            services.AddSingleton<ICatFactsService, CatFactsService>();
        }
    }
}
