using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using DotNet.UnitTestingFrameworks.API;
using DotNet.UnitTestingFrameworks.API.Utils;

[assembly: FunctionsStartup(typeof(Startup))]
namespace DotNet.UnitTestingFrameworks.API
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddAppConfiguration();
            builder.Services.AddPersistances();
            builder.Services.AddServices();
            builder.Services.AddOtherDependencies();
        }
    }
}
