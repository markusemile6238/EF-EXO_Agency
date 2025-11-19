using Domaine.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    public class DestinationConfig : IEntityTypeConfiguration<Destination>
    {
        public void Configure(EntityTypeBuilder<Destination> builder)
        {
            builder.ToTable("Destinations");

            builder.Property(d => d.Id).ValueGeneratedOnAdd();
            builder.Property(d => d.Country).IsRequired().HasMaxLength(150);
            builder.Property(d => d.City).IsRequired().HasMaxLength(100);
            builder.Property(d => d.Description).IsRequired().HasMaxLength(255);

            // constrains
            builder.HasKey(d => d.Id).HasName("PK_Destination");
            builder.HasIndex(d => d.Country).IsUnique();

            
           
        }
    }
}
