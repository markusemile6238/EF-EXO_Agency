using DAL.Configuration;
using DAL.Seeds;
using Domaine.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class AgDbContext : DbContext
    {
        public DbSet<Destination> Destinations {  get; set; }
        public DbSet<Customer> Customers {  get; set; }
        public DbSet<Activity> Activities {  get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server= GOS-VDI509\\TFTIC; Initial Catalog=ExoAgency; Integrated Security = True; Encrypt = True; Trust Server Certificate = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DestinationConfig());
            modelBuilder.ApplyConfiguration(new DestinationSeed());

            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new CustomerSeed());

            modelBuilder.ApplyConfiguration(new ActivityConfig());
            modelBuilder.ApplyConfiguration(new ActivitySeed());

            modelBuilder.Entity("ActivityBooked")
                .HasData(
                    new { BookingId = 1, ActivityId = 1 },
                    new { BookingId = 1, ActivityId = 2 },
                    new { BookingId = 2, ActivityId = 3 }
                 );
        }
            
    };
        
}
