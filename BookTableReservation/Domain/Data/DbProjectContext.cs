using Domain.Configuration;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Domain.Data
{
    public class DbProjectContext : DbContext
    {

        public DbProjectContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Seat> Seat { get; set; }
        public DbSet<Booking> Booking { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new SeatConfiguration());
        }

    }

}
