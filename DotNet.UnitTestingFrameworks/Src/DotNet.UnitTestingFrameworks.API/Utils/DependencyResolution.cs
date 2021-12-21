using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DotNet.UnitTestingFrameworks.BLL.IService;
using DotNet.UnitTestingFrameworks.BLL.Service;
using DotNet.UnitTestingFrameworks.BLL.Strategies.Context;
using DotNet.UnitTestingFrameworks.BLL.Strategies.Factory;
using DotNet.UnitTestingFrameworks.Common.Configuration;
using DotNet.UnitTestingFrameworks.DAL.IPersistence;
using DotNet.UnitTestingFrameworks.DAL.Persistence;
using DotNet.UnitTestingFrameworks.DAL.StorageAccess;

namespace DotNet.UnitTestingFrameworks.API.Utils
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
            services.AddTransient<IStorageWriter, FileStorageWriter>();
            services.AddTransient<IStorageReader, FileStorageReader>();
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
