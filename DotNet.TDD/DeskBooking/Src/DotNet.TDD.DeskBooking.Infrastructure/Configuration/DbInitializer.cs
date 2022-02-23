using DotNet.TDD.DeskBooking.Infrastructure.Context;

namespace DotNet.TDD.DeskBooking.Infrastructure.Configuration
{
    public static class DbInitializer
    {
        public static void Initialize(DeskBookingContext context)
        {
            // Do I need this??? This isn't needed for the migrations
            context.Database.EnsureCreated();
        }
    }
}
