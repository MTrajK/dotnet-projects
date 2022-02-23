using DotNet.TDD.DeskBooking.Infrastructure.Context;

namespace DotNet.TDD.DeskBooking.Infrastructure.Configuration
{
    public static class DbInitializer
    {
        public static void Initialize(DeskBookingContext context)
        {
            // Just in case if the DB isn't created with the existing migrations
            context.Database.EnsureCreated();
        }
    }
}
