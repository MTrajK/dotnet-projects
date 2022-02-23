using DotNet.TDD.DeskBooking.Application.IService;
using DotNet.TDD.DeskBooking.Application.Service;
using DotNet.TDD.DeskBooking.Domain.IPersistance;
using DotNet.TDD.DeskBooking.Infrastructure.Context;
using DotNet.TDD.DeskBooking.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace DotNet.TDD.DeskBooking.API.Extensions
{
    public static class DependencyResolution
    {
        public static void AddDatabaseContext(this IServiceCollection services)
        {
            services.AddDbContext<DeskBookingContext>(options =>
                options.UseSqlServer("Server=localhost;Database=DeskBooking;User Id=sa;Password=DotNetTDD2022;TrustServerCertificate=True;"));
        }

        public static void AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IEmployeePersistance, EmployeePersistance>();
            services.AddTransient<IDeskPersistance, DeskPersistance>();
        }

        public static void AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IDeskService, DeskService>();
        }
    }
}
