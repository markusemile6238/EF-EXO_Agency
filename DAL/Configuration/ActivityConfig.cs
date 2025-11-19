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
    public class ActivityConfig : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
           // builder.ToTable("Activities");

            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Title).HasMaxLength(150).IsRequired();
            builder.Property(a => a.Price).HasColumnType("decimal").IsRequired();
            builder.Property(a => a.Description).HasMaxLength(200).IsRequired();

            //constrains
            builder.HasKey(a => a.Id).HasName("PK_Activity");
            builder.ToTable(a => a.HasCheckConstraint("CK_Activity__Price", "[price] > 0"));

            //relations
            // activity <> destination
            builder.HasOne(a => a.Destination)
                .WithMany(d => d.Activities)
                .HasForeignKey("DestinationId")
                .IsRequired();

        }
                
    }
}
