using DotNet.TDD.DeskBooking.Application.IService;
using DotNet.TDD.DeskBooking.Application.Service;
using DotNet.TDD.DeskBooking.Domain.IPersistance;
using DotNet.TDD.DeskBooking.Infrastructure.Context;
using DotNet.TDD.DeskBooking.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace DotNet.TDD.DeskBooking.API.Utils
{
    public static class DependencyResolution
    {
        public static void AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DeskBookingContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DeskBookingDB")));
        }

        public static void AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IEmployeePersistance, EmployeePersistance>();
            services.AddTransient<IDeskPersistance, DeskPersistance>();
            services.AddTransient<IBookingPersistance, BookingPersistance>();
        }

        public static void AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IDeskService, DeskService>();
            services.AddTransient<IBookingService, BookingService>();
        }
    }
}
