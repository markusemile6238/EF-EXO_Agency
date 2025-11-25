using DAL.Configuration;
using DAL.Seeds;
using Domaine.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AgDbContext : DbContext
    {
        public AgDbContext(DbContextOptions<AgDbContext> options) :base(options) { }
       

        public DbSet<Destination> Destinations {  get; set; }
        public DbSet<Customer> Customers {  get; set; }
        public DbSet<Activity> Activities {  get; set; }
        public DbSet<Booking> Bookings { get; set; }
        
       /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server= GOS-VDI509\\TFTIC; Initial Catalog=ExoAgency; Integrated Security = True; Encrypt = True; Trust Server Certificate = True");
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DestinationConfig());
            modelBuilder.ApplyConfiguration(new DestinationSeed());

            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new CustomerSeed());

            modelBuilder.ApplyConfiguration(new ActivityConfig());
            modelBuilder.ApplyConfiguration(new ActivitySeed());

            modelBuilder.ApplyConfiguration(new BookingConfig());
            modelBuilder.ApplyConfiguration(new BookingSeed());


            modelBuilder.Entity("ActivityBooked")
                .HasData(
                    new { BookId = 1, ActivityId = 1 },
                    new { BookId = 1, ActivityId = 2 },
                    new { BookId = 2, ActivityId = 3 }
                 );
        }

    };
        
}
