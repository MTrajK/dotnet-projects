using Endava.DotNetCommunity.BLL.IService;
using Endava.DotNetCommunity.BLL.Service;
using Endava.DotNetCommunity.BLL.Strategies.Context;
using Endava.DotNetCommunity.BLL.Strategies.Factory;
using Endava.DotNetCommunity.Common.Configuration;
using Endava.DotNetCommunity.DAL.IPersistence;
using Endava.DotNetCommunity.DAL.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Endava.DotNetCommunity.API.Utils
{
    public static class DependencyResolution
    {
        public static void AddAppConfiguration(this IServiceCollection services)
        {
            IConfigurationRoot appConfiguration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"local.settings.json")
                .Build();

            services.Configure<FileStorageOptions>(appConfiguration.GetSection(FileStorageOptions.FileStorageSettingsSection));
        }

        public static void AddPersistances(this IServiceCollection services)
        {
            services.AddTransient<IUserPersistence, UserPersistence>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICreateUserService, CreateUserService>();
            services.AddTransient<IGetUserService, GetUserService>();
        }

        public static void AddOtherDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStrategyFactory, CalculatorFactory>();
            services.AddTransient<IStrategyContext, CalculatorContext>();
        }
    }
}
