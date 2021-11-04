using Endava.DotNetCommunity.API;
using Endava.DotNetCommunity.API.Utils;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Endava.DotNetCommunity.API
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
