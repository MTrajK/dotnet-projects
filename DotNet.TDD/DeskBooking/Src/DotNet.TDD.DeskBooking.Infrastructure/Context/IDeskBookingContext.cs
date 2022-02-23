using DotNet.TDD.DeskBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNet.TDD.DeskBooking.Infrastructure.Context
{
    public interface IDeskBookingContext
    {
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<DeskEntity> Desks { get; set; }
        public DbSet<BookingEntity> Bookings { get; set; }

        public int SaveContextChanges();
    }
}
