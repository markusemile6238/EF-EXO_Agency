using AppAgency.Helper;
using Domaine.Builder;
using Domaine.Interfaces.IBooking;
using Domaine.Model;
using Domaine.Model.DTO;
using Domaine.Services;
using System.Globalization;


namespace AppAgency.Menu
{
    public class BookingMenu
    {
        private readonly ActivityService _activityService;
        private readonly DestinationService _destinationService;
        private readonly CustomerService _customerService;
        private readonly BookingService _bookingService;

        public BookingMenu(
            ActivityService activityService,
            DestinationService destinationService,
            CustomerService customerService,
            BookingService bookingService)
        {
            _activityService = activityService;
            _destinationService = destinationService;
            _customerService = customerService;
            _bookingService = bookingService;
        }

        public async Task BookingATrip()
        {
            BookingDto newReservation = new BookingDto();
            Customer newCustomer = new Customer();
            DestinationDto currentDestination = new DestinationDto();
            bool jeReserve = true;
            string texte = "";
            do
            {
                Console.Clear();
                // nouvelles reservation
                DesignHelper.ApplyStyle(StyleText.TITLE, "\nNouvelle reservation");

                // entrer le nom du client
                #region entrer nom client
                do
                {
                    DesignHelper.ApplyStyle(StyleText.INFO, "\n[1] Veuillez entrer le nom du client.");
                    string? noc = Console.ReadLine();
                    if (!String.IsNullOrEmpty(noc))
                    {
                        newCustomer.Name = noc.Trim();
                        DesignHelper.ApplyStyle(StyleText.CONFIRMATION, "Confirmez vous le nom [O]ui [N]on");
                        if (NavigationHelper.ShouldContinue()) break;
                        continue;

                    }
                    else
                    {
                        DesignHelper.ApplyStyle(StyleText.ERROR, "Veuillez entrez un nom de client !");
                        continue;
                    }
                } while (true);
                #endregion

                texte += $"\nReservation au nom de {newCustomer.Name}";

                Console.Clear();
                //Console.WriteLine(texte);

                // entrer la date de reservation
                #region entrer la date
                DateTime tripDate;
                do
                {
                    Console.Clear();
                    DesignHelper.ApplyStyle(StyleText.INFO, "\n\nVeuillez indiquez la date de reservation ! ex : 29/12/1972");
                    string? rd = Console.ReadLine();
                    if (DateTime.TryParseExact(rd, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tripDate) && 
                        tripDate > DateTime.UtcNow)
                    {
                        DesignHelper.ApplyStyle(StyleText.CONFIRMATION, "Confirmez vous la date [O]ui [N]on");
                        if (NavigationHelper.ShouldContinue())
                        {
                            break;

                        }
                        else
                        {
                            DesignHelper.ApplyStyle(StyleText.ERROR, "Veuillez saisir une nouvelle date !");
                            Console.WriteLine();
                            continue;
                        }
                    }
                    else
                    {
                        DesignHelper.ApplyStyle(StyleText.ERROR, "Veuillez saisir une date valide !");
                        continue;
                    }

                } while (true);
                #endregion
                newReservation.BookingDate = tripDate;

                texte += $"\nDate de réservation : {newReservation.BookingDate}";
                Console.Clear();
                // Console.WriteLine(texte);

                // choisir l'id de destination
                int destinationId = 0;
                #region choisir la destination
                DesignHelper.ApplyStyle(StyleText.TITLE, "\nChoisissons votre destination ci-dessous");
                var allDestinations = await _destinationService.GetAlldestinationAsync();

                if (allDestinations.Any() && allDestinations is List<Destination> lofd)
                {
                    // affichage de la liste
                    DesignHelper.ApplyStyle(StyleText.INFO, "Voici les destinations");
                    foreach (Destination destination in allDestinations.OrderBy(d => d.Country).ThenBy(c => c.City).ToList())
                    {
                        Console.WriteLine($"[{destination.Id,-2}]    {destination.City}");
                    }
                    do
                    {

                        DesignHelper.ApplyStyle(StyleText.INFO, "Faites votre choix ! ");
                        // choix de la destination
                        string? dest = Console.ReadLine();
                        if (int.TryParse(dest, out destinationId) && allDestinations.Any(d => d.Id == destinationId))
                        {
                            DesignHelper.ApplyStyle(StyleText.CONFIRMATION, "Confirmez vous la destination [O]ui [N]on");
                            if (NavigationHelper.ShouldContinue())
                            {
                                currentDestination.Country = allDestinations.ElementAt(destinationId - 1).Country;
                                currentDestination.City = allDestinations.ElementAt(destinationId - 1).City;
                                currentDestination.Id = allDestinations.ElementAt(destinationId - 1).Id;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            DesignHelper.ApplyStyle(StyleText.ERROR, $"l'Id {destinationId} n'exist pas dans la liste");
                            continue;
                        }
                    } while (true);
                }
                else
                {
                    DesignHelper.ApplyStyle(StyleText.ERROR, "Désolé, mais nous n'avons trouvé aucune destination !");
                }
                #endregion

                texte += $"\nDestination choisi : {currentDestination.Country} - {currentDestination.City}";
                Console.Clear();
                //Console.Write(texte);

                // choisir activite
                #region choisir les activité
                DesignHelper.ApplyStyle(StyleText.TITLE, "\nChoisissons les activités pour cette destination");
                int activiteId;
                var allActivities = await _activityService.GetAllByDestinationId(currentDestination.Id);
                if (allActivities.Any() && allActivities is List<Activity> lact)
                {
                    // affichage des activité en fonction de l'id de destination
                    DesignHelper.ApplyStyle(StyleText.INFO, "\n\nVoici les activitées possible pour cette destination");
                    foreach (var act in lact)
                    {
                        Console.WriteLine($"[ ID:{act.Id,-1}]    {act.Title,-40}         {act.Price}€\n");
                    }
                    do
                    {
                        DesignHelper.ApplyStyle(StyleText.INFO, "\n\nChoisissez l'ID  de votre choix");
                        string? ac = Console.ReadLine(); // choix de l'activité
                        if (int.TryParse(ac, out activiteId) && allActivities.Any(a => a.Id == activiteId))
                        {
                            DesignHelper.ApplyStyle(StyleText.CONFIRMATION, "\nConfirmez vous cette activitée [O]ui [N]on");
                            if (NavigationHelper.ShouldContinue())
                            {
                                var selectedAcivity = allActivities.First(a => a.Id == activiteId);
                                newReservation.Activities.Add(selectedAcivity);
                                DesignHelper.ApplyStyle(StyleText.SUCCESS, "\nActivité ajouter avec success");

                                DesignHelper.ApplyStyle(StyleText.CONFIRMATION, "Souhaitezvous ajouter une autre activitée [O]ui [N]on");
                                if (NavigationHelper.ShouldContinue()) { continue; } else { break; }

                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            DesignHelper.ApplyStyle(StyleText.ERROR, "Veuillez choisir un ID de la liste ci-dessus");
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
                double total = (double)newReservation.Activities.Sum(a => (double)a.Price);
                texte += $"Total des activité :{total} Euro";
                DesignHelper.ApplyStyle(StyleText.SUMMARY, texte);

                // si reservation accepter
                DesignHelper.ApplyStyle(StyleText.CONFIRMATION, "\nConfirmez la réservation [O]ui [N]on");
                if (NavigationHelper.ShouldContinue())
                {
                    // sauver le client
                    try
                    {
                        newCustomer = await _customerService.WithReturnAddAsyn(newCustomer);
                        DesignHelper.ApplyStyle(StyleText.SUCCESS, "Nouveau client sauver !");

                    }
                    catch (Exception Ex)
                    {
                        DesignHelper.ApplyStyle(StyleText.ERROR, Ex.Message);
                        throw new InvalidOperationException("Impossible d'enregistrer le client");
                    }
                    // on sauve la reservation                  

                    try
                    {

                        Booking book = BookingBuilder.Create()
                            .SetCustomerId(newCustomer.Id)
                            .SetReservationDate(newReservation.BookingDate)
                            .SetDestinationId(destinationId)
                            .SetActivities(newReservation.Activities)
                            .Build();

                        foreach (var activity in book.Activities)
                        {
                            Console.WriteLine(activity.Id);
                        }

                        await _bookingService.AddAsync(book);
                        DesignHelper.ApplyStyle(StyleText.SUCCESS, "Reservation sauver avec success !");
                    }
                    catch (Exception Ex)
                    {
                        DesignHelper.ApplyStyle(StyleText.ERROR, Ex.Message);
                        // Affichez TOUTE l'information de l'exception
                        Console.WriteLine($" ERREUR COMPLÈTE: {Ex}");
                        Console.WriteLine($" Message: {Ex.Message}");
                        Console.WriteLine($" StackTrace: {Ex.StackTrace}");

                        if (Ex.InnerException != null)
                        {
                            Console.WriteLine($"🔍 INNER EXCEPTION: {Ex.InnerException.Message}");
                            Console.WriteLine($"📝 INNER StackTrace: {Ex.InnerException.StackTrace}");
                        }

                        DesignHelper.ApplyStyle(StyleText.ERROR, Ex.Message);
                        throw new InvalidOperationException("Impossible d'enregistrer la réservation");
                    }



                }
                // recommencer ou sortir vers le menu
                Console.WriteLine("\nSouhaitrez vous faire une nouvelles reservation ? [O]ui [N]on");
                if (!NavigationHelper.ShouldContinue()) jeReserve = false;

            } while (jeReserve);





        }


    }

}

