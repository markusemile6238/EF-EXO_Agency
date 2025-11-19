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
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
  
            // constrains
            builder.HasKey(b => b.Id).HasName("PK_Customer");

            //relation
            // customer<>booking
            builder.HasMany(b => b.Bookings)
                .WithOne(b => b.Customer)
                .HasForeignKey(b => b.CustomerId)
                .IsRequired();
      



        }
    }
}
