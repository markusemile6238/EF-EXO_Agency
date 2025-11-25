using Domaine.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Domaine.Model;
using Domaine.Model.DTO;
using Domaine.Builder;
using System.Collections.ObjectModel;

namespace AppAgency.Menu
{
    public class ActivityMenu
    {
        private readonly ActivityService _activityService;
        private readonly DestinationService _destinationService;

        public ActivityMenu(
            ActivityService activityService,
            DestinationService destinationService 
            )
        {
            _activityService = activityService;
            _destinationService = destinationService;
        }

        public async Task ShowAll()
        {
            var list = await _activityService.GetActivitiesAsync();
            Console.WriteLine($"Voici toute les activités");
            foreach (var item in list)
            {
                Console.WriteLine($"[{item.Id,1}] :    {item.Title,-15} : {item.Price,2}€ ");
           }
           Console.ReadLine();
        }

        public async Task AddActivity()
        {
            ActivityDto? dto = new ActivityDto(title:null,description:null,price:null,destinationId:null){};
            var destinations = await _destinationService.GetAlldestinationAsync();
            if (destinations == null) 
            {
                Console.WriteLine("Aucune destination de disponible");
                Console.Read();
                return;
            }
            List<int> allIdDestination = destinations.Select(d=>d.Id).ToList();
            Destination dest;
            Console.WriteLine($""""
                ****************************************************
                Nous allons ensemble ajouter une nouvelles activité
                ****************************************************\n
                """");
            foreach (var destination in destinations)
            {
                Console.WriteLine($"[{destination.Id,1}] :    {destination.Country} ");
            }
            int selectedDestinationId;
            #region selectDestinationId
            do
            {
                Console.Write("Veuillez sélectionner un ID de destination : ");
                string input = Console.ReadLine();
                if(int.TryParse(input, out   selectedDestinationId) && allIdDestination.Contains(selectedDestinationId))
                {
                    dest = destinations.ElementAt(selectedDestinationId);
                    break;
                }
                else
                {
                    Console.WriteLine("ID invalide. Veuillez choisir un ID valide dans la liste.");
                }

            } while (true);
            #endregion
            dto.DestinationId = dest.Id-1;

            string selectedTitle;
            #region selectTitle
            do
            {
                Console.Write("Veuillez entrez un titre d'activité : ");
                string input = Console.ReadLine();
                if (!String.IsNullOrEmpty(input))
                {
                    selectedTitle = input;
                    break;
                }
                else
                {
                    Console.WriteLine("Veuillez entrez un titre d'activité !");
                }
            } while (true);
            #endregion
            dto.Title = selectedTitle;

            string SelectedDescription;
            #region selectDescription
            do
            {
                Console.Write("Veuillez indiquer une description de l'activité : ");
                string input = Console.ReadLine();
                if (!String.IsNullOrEmpty(input))
                {
                    SelectedDescription = input;
                    break;
                }
                else
                {
                    Console.WriteLine("Veuillez entrez une description !");
                }
            } while (true);
            #endregion
            dto.Description = SelectedDescription;

            decimal selectedPrice;
            #region SetPrice
            do
            {
                Console.Write("Veuillez indiquer le prix de l'activité : ");
                string input = Console.ReadLine();
                if(decimal.TryParse(input, out selectedPrice) && selectedPrice > 0){
                    break;
                }
                else
                {
                    Console.WriteLine("Veuillez entrer un prix raisonnable !");
                }
            } while (true);
            #endregion
            dto.Price = selectedPrice;

            Console.WriteLine("************************************************************");
            Console.WriteLine("************************************************************");
            Console.WriteLine("Voici la nouvelle activité qui sera sauver");
            Console.WriteLine($"Le pays de destination : {dest.Country}:{dto.DestinationId}");
            Console.WriteLine($"Dans La ville : {dest.City}");
            Console.WriteLine("************************************************************");
            Console.WriteLine($"Le Titre de l'activité est : {dto.Title}");
            Console.WriteLine($"Sa description : {dto.Description}");
            Console.WriteLine($"Et son prix : {dto.Price}");
            Console.WriteLine("************************************************************");
            Console.WriteLine("************************************************************");
            Console.WriteLine("[Y]es ou [N]o or [R]eset ");
            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.Y:
                    await _activityService.AddAsync(dto);
                    break;
                case ConsoleKey.R:
                    await AddActivity();
                    break;
                default:
                    return;
            }

        }


    }
}
