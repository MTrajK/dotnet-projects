using DotNet.TDD.DeskBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNet.TDD.DeskBooking.Infrastructure.Context
{
    public class DeskBookingContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Desk> Desks { get; set; }

        public DeskBookingContext(DbContextOptions<DeskBookingContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Desk>().ToTable("Desk");
        }
    }
}
