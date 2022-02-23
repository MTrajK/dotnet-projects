using DotNet.TDD.DeskBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNet.TDD.DeskBooking.Infrastructure.Context
{
    public class DeskBookingContext : DbContext, IDeskBookingContext
    {
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<DeskEntity> Desks { get; set; }
        public DbSet<BookingEntity> Bookings { get; set; }

        public DeskBookingContext(DbContextOptions<DeskBookingContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // No need from Fluent API mapping! 
            // The tables are already created using the properties from EmployeeEntity, DeskEntity and BookingEntity.
            // Id is taken as primary key everywhere, in BookingEntity DeskId and EmployeeId are taken as foreign keys.
            // Only seed some DB data here if you need.
        }

        public int SaveContextChanges()
        {
            return SaveChanges();
        }
    }
}
