using DotNet.TDD.DeskBooking.Infrastructure.Configuration;
using DotNet.TDD.DeskBooking.Infrastructure.Context;

namespace DotNet.TDD.DeskBooking.API.Extensions
{
    public static class CreateDatabase
    {
        public static void CreateDbIfNotExists(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<DeskBookingContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}
