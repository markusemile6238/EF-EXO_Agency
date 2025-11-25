using DAL.Repositories;
using Domaine.Model;
using Domaine.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;

public class DestinationMenu
{
  
    private readonly DestinationService _destinationService;

    public DestinationMenu(DestinationService destinationService)
    {
        _destinationService = destinationService;
    }

    public async Task ShowAll()
    {
        var list = await _destinationService.GetAlldestinationAsync(); 
        if(list.Any() && list is List<Destination> destinationList)
        {
            
            var sortedList = list.OrderBy(d=>d.Country).ThenBy(d=>d.City).ToList();
            Console.WriteLine("Voici les destination");
            foreach (var item in sortedList)
            {
                Console.WriteLine($"[ID:{item.Id,2}] :   {item.Country,10}   : {item.City} ");
            }
        }
            Console.WriteLine("\n\n[ENTER] to continue");
            Console.ReadLine();
    }

   



    public async Task AddDestination() { 
    
           Destination newDestination = new Destination(){Country="",City="",Description=""};

            Console.WriteLine("Veuillez Entrer une Nouvelle Destination");
        do
        {
            Console.WriteLine("Le Pays");
            newDestination.Country = Console.ReadLine();

        } while (string.IsNullOrEmpty(newDestination.Country));
        do
        {
            Console.WriteLine("La Ville");
            newDestination.City = Console.ReadLine();

        } while (string.IsNullOrEmpty(newDestination.City));
        do
        {
            Console.WriteLine("La Description");
            newDestination.Description = Console.ReadLine();

        } while (string.IsNullOrEmpty(newDestination.Description));

        Console.WriteLine("************************************************************");
        Console.WriteLine("************************************************************");
        Console.WriteLine("Voici la nouvelle destination qui sera sauver");
        Console.WriteLine($"Le pays : {newDestination.Country}");
        Console.WriteLine($"La ville : {newDestination.City}");
        Console.WriteLine($"Et sa description : {newDestination.Description}");
        Console.WriteLine("************************************************************");
        Console.WriteLine("************************************************************");
        Console.WriteLine("[Y] ou [N] pour sauver ou annuler");
        var key = Console.ReadKey(true);
        switch (key.Key)
        {
            case ConsoleKey.Y:
                    await _destinationService.AddAsync(newDestination);
                break;
            default:
                return;
        }
        return;

      





    }
}