using Domaine.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Seeds
{
    public class CustomerSeed : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer() { Id=1, Name="Durant" },
                new Customer() { Id=2, Name="Dupont" },
                new Customer() { Id=3, Name="Smith" }
                );
        }
    }
}
