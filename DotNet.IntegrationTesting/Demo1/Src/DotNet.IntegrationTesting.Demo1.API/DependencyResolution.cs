namespace DotNet.IntegrationTesting.Demo1.API
{
    using DotNet.IntegrationTesting.Demo1.Application.IService;
    using DotNet.IntegrationTesting.Demo1.Application.Service;

    public static class DependencyResolution
    {
        public static void AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddSingleton<ITemperatureConversionService, TemperatureConversionService>();
        }
    }
}
