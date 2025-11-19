using Domaine.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Seeds
{
    public class DestinationSeed : IEntityTypeConfiguration<Destination>
    {
        public void Configure(EntityTypeBuilder<Destination> builder)
        {
            builder.HasData(
                new Destination() { Id=1,Country="Belgique",City="Bruxelles", Description="Découvrez le plat pays a travers nos activité"},
                new Destination() { Id=2,Country="France",City="Paris", Description="Voyagez a travers nos régions..."}
                );
        }
    }
}
