using Domaine.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuration
{
    public class BookingConfig : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Bookings");

            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.BookingDate).IsRequired().HasColumnType("date");
            builder.Property(b => b.CustomerId).IsRequired();

            //constrains
            builder.HasKey(b => b.Id).HasName("PK_Booking");
            builder.ToTable(b => b.HasCheckConstraint("CK_Bookind_Date","[BookingDate] >= GetDate()"));

            // relations

            builder.HasOne(b => b.Customer)
               .WithMany(c => c.Bookings)
               .HasForeignKey(b => b.CustomerId);

            // booking<>activity
            builder.HasMany(b => b.Activities)
                .WithMany(a => a.Bookings)
                .UsingEntity(
                "ActivityBooked",
                     left => left.HasOne(typeof(Activity))
                             .WithMany()
                             .HasForeignKey("ActivityId")
                             .HasPrincipalKey(nameof(Activity.Id)),
                     right => right.HasOne(typeof(Booking))
                             .WithMany()
                             .HasForeignKey("BookId")
                             .HasPrincipalKey(nameof(Booking.Id)), 
                     join => join.HasKey("BookId","ActivityId"));

          
           
        }
    }

}
