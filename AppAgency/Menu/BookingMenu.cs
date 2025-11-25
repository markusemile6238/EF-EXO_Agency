using AppAgency.Helper;
using Domaine.Model;
using Domaine.Model.DTO;
using Domaine.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAgency.Menu
{
    public class BookingMenu
    {
        private readonly ActivityService _activityService;
        private readonly DestinationService _destinationService;
        private readonly CustomerService _customerService;

        public BookingMenu(ActivityService activityService, DestinationService destinationService, CustomerService customerService)
        {
            _activityService = activityService;
            _destinationService = destinationService;
            _customerService = customerService;
        }

        public async Task BookingATrip()
        {
            BookingDto newReservation = new BookingDto();
            CustomerDto newCustomer = new CustomerDto();
            DestinationDto currentDestination = new DestinationDto();
            bool jeReserve = true;
            string texte = "";
            ConsoleKeyInfo k;
            do
            {
                Console.Clear();
                // nouvelles reservation
                Console.WriteLine(" Nouvelle reservation ");

                // entrer le nom du client
                #region entrer nom client
                do
                {
                    Console.WriteLine("[1] Veuillez entrer le nom du client.");
                    string? noc = Console.ReadLine();
                    if (!String.IsNullOrEmpty(noc))
                    {
                        newCustomer.Name = noc.Trim();
                        Console.WriteLine("Confirmez vous le nom [O]ui [N]on");
                        if (NavigationHelper.ShouldContinue()) break;
                        continue;

                    }
                    else
                    {
                        Console.WriteLine("Veuillez entrez un nom de client !");
                        continue;
                    }
                } while (true);
                #endregion

                texte += $"\nReservation au nom de {newCustomer.Name}";

                Console.Clear();
                Console.WriteLine(texte);

                // entrer la date de reservation
                #region entrer la date
                DateTime tripDate;
                do
                {
                    Console.WriteLine("\n\nVeuillez indiquez la date de reservation ! ex : 29/12/1972");
                    string rd = Console.ReadLine();
                    if (DateTime.TryParseExact(rd, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tripDate))
                    {
                        Console.WriteLine("Confirmez vous la date [O]ui [N]on");
                        if (NavigationHelper.ShouldContinue()) break;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Veuillez entrer une date valide !");
                    }

                } while (true);
                #endregion
                newReservation.BookingDate = tripDate;

                texte += $"\nDate de réservation : {newReservation.BookingDate}";
                Console.Clear();
                Console.WriteLine(texte);

                // choisir l'id de destination
                int destinationId;
                #region choisir la destination
                Console.WriteLine("\n\nChoisissons votre destination ci-dessous");
                var allDestinations = await _destinationService.GetAlldestinationAsync();

                if (allDestinations.Any() && allDestinations is List<Destination> lofd)
                {
                    // affichage de la liste
                    foreach (Destination destination in allDestinations.OrderBy(d => d.Country).ThenBy(c => c.City).ToList())
                    {
                        Console.WriteLine($"[{destination.Id,-2}]    {destination.City}");
                    }
                    do
                    {

                        Console.WriteLine("Faites votre choix ! ");
                        // choix de la destination
                        string? dest = Console.ReadLine();
                        if (int.TryParse(dest, out destinationId) && allDestinations.Any(d => d.Id == destinationId - 1))
                        {
                            Console.WriteLine("Confirmez vous la destination [O]ui [N]on");
                            if (NavigationHelper.ShouldContinue())
                            {
                                currentDestination.Country = allDestinations.ElementAt(destinationId - 1).Country;
                                currentDestination.City = allDestinations.ElementAt(destinationId - 1).City;
                                currentDestination.Id = destinationId;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"l'Id {destinationId} n'exist pas dans la liste");
                            continue;
                        }
                    } while (true);
                }
                else
                {
                    Console.WriteLine("Désolé, mais nous n'avons trouvé aucune destination !");
                }
                #endregion

                texte += $"\nDestination choisi : {currentDestination.Country} - {currentDestination.City}";
                Console.Clear();
                Console.Write(texte);

                // choisir activite
                #region choisir les activité
                Console.WriteLine("\n\nChoisissons les activités pour cette destination\n\n");
                int activiteId;
                var allActivities = await _activityService.GetAllByDestinationId(currentDestination.Id);
                if (allActivities.Any() && allActivities is List<Activity> lact)
                {
                    // affichage des activité en fonction de l'id de destination
                    foreach (var act in lact)
                    {
                        Console.WriteLine($"[ ID:{act.Id,-1}]    {act.Title,-40}         {act.Price}€\n");
                    }
                    do
                    {
                        Console.WriteLine("\n\nChoisissez l'ID  de votre choix");
                        string? ac = Console.ReadLine(); // choix de l'activité
                        if (int.TryParse(ac, out activiteId) && allActivities.Any(a => a.Id == activiteId))
                        {
                            Console.WriteLine("\nConfirmez vous cette activitée [O]ui [N]on");
                            if (NavigationHelper.ShouldContinue())
                            {
                                newReservation.Activities.Add(allActivities.ElementAt(activiteId-1));                                
                                Console.WriteLine("\nActivité ajouter avec success");

                                Console.WriteLine("Souhaitezvous ajouter une autre activitée [O]ui [N]on");
                                if (NavigationHelper.ShouldContinue()) { continue; } else { break; }

                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Veuillez choisir un ID de la liste ci-dessus");
                            continue;
                        }

                    } while (true);
                }
                #endregion

                texte += $"\nActivitée(s) choisis :\n";
                foreach (var item in newReservation.Activities)
                {
                    texte += $" * {item.Title,-50}     | {item.Price} Euro\n";
                }


                // on affiche la reservation
                Console.Clear();
                double total = (double) newReservation.Activities.Sum(a => (double) a.Price);
                texte += $"Total des activité :{total} Euro";
                Console.WriteLine(texte);               


                // si reservation accepter

                // sauver le client

                // on sauve la reservation

                // recommencer ou sortir vers le menu
                Console.WriteLine("\nSouhaitrez vous faire une nouvelles reservation ? [O]ui [N]on");
                if (!NavigationHelper.ShouldContinue()) jeReserve = false;

            } while (jeReserve);





        }


    }

}

