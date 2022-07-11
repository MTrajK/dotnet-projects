using DotNet.TDD.DeskBooking.Infrastructure.Configuration;
using DotNet.TDD.DeskBooking.Infrastructure.Context;

namespace DotNet.TDD.DeskBooking.API.Utils
{
    public static class CreateDatabase
    {
        public static void CreateDbIfNotExists(this IApplicationBuilder appBuilder)
        {
            using (var scope = appBuilder.ApplicationServices.CreateScope())
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
