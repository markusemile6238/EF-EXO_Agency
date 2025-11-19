using Domaine.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Seeds
{
    public class ActivitySeed : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasData(
                new{ Id=1, Title="Visite de Paris en Bateau la nuit", Description="Découvre les monuments les plus célèbres sur visible depuis le bord de la Seine...", Price=45M,DestinationId=2},                
                new{ Id=2, Title="Visite de Paris en Bus", Description="Découvre les monuments tranquillement depuis nos bus a deux étages...", Price=35M, DestinationId=2},                
                new{ Id=3, Title="Visite de Bruxelles", Description="Avec notre guide découvrez l'histoire de cette villes...", Price=60M, DestinationId=1}
                );
        }
    }
}
