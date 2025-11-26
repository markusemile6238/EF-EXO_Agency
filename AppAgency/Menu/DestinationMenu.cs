using AppAgency.Helper;
using Domaine.Model;
using Domaine.Services;

public class DestinationMenu
{

    private readonly DestinationService _destinationService;

    public DestinationMenu(DestinationService destinationService)
    {
        _destinationService = destinationService;
    }

    #region Afficher les destination
    public async Task ShowAll()
    {
        Console.Clear();
        var destinations = await _destinationService.GetAlldestinationAsync();


        if (destinations.Any() == true)
        {
            var sortedDestination = destinations
                .OrderBy(x => x.Country)
                .ThenBy(x => x.City)
                .ToList();

            DesignHelper.ApplyStyle(StyleText.TITLE, "\nVoici la liste des destination");
            // affichage des destination
            DesignHelper.ShowList(destinations, ["Id", "Country", "City"], StyleDisplayData.TABLE);
            DesignHelper.ApplyStyle(StyleText.CONFIRMATION, "Appuyer sur une touche pour retour menu");
            if (NavigationHelper.ShouldContinue()) return;




        }



    }
    #endregion

    #region Ajouter une destination
    public async Task AddDestination()
    {
        do
        {
            Console.Clear();
            Destination newDestination = new Destination() { Country = "", City = "", Description = "" };

            DesignHelper.ApplyStyle(StyleText.TITLE, "\nCréation d'une nouvelle Destination");

            #region ajouter un pays
            do
            {
                DesignHelper.ApplyStyle(StyleText.INFO, "Saisir le pays : ");
                string newCountry = Console.ReadLine();
                if (!string.IsNullOrEmpty(newCountry) && newCountry.Length > 1)
                {
                    DesignHelper.ApplyStyle(StyleText.CONFIRMATION, "\nConfirmez le Pays [O]ui [N]on ");
                    if (NavigationHelper.ShouldContinue())
                    {
                        newDestination.Country = newCountry;
                        break;
                    }
                    else
                    {

                        DesignHelper.ApplyStyle(StyleText.ERROR, "Tres bien recommencer");
                        continue;
                    }
                }
                else
                {
                    DesignHelper.ApplyStyle(StyleText.ERROR, "Veuillez saisir à nouveau destination");
                    continue;
                }
            } while (true);
            #endregion

            #region ajouter une ville
            do
            {

                DesignHelper.ApplyStyle(StyleText.INFO, "Saisir la ville : ");
                string? newCity = Console.ReadLine();
                if (!string.IsNullOrEmpty(newCity) && newCity?.Length > 1)
                {
                    DesignHelper.ApplyStyle(StyleText.CONFIRMATION, "\nConfirmez la ville [O]ui [N]on ");
                    if (NavigationHelper.ShouldContinue())
                    {
                        newDestination.City = newCity;
                        break;
                    }
                    else
                    {

                        DesignHelper.ApplyStyle(StyleText.ERROR, "Tres bien recommencer");
                        continue;
                    }
                }
                else
                {
                    DesignHelper.ApplyStyle(StyleText.ERROR, "Veuillez saisir à nouveau la ville");
                    continue;
                }
            } while (true);
            #endregion

            #region ajouter description
            do
            {

                DesignHelper.ApplyStyle(StyleText.INFO, "Saisir la description: ");
                string? newDesc = Console.ReadLine();
                if (!string.IsNullOrEmpty(newDesc) && newDesc?.Length > 1)
                {
                    DesignHelper.ApplyStyle(StyleText.CONFIRMATION, "\nConfirmez la deszcription [O]ui [N]on ");
                    if (NavigationHelper.ShouldContinue())
                    {
                        newDestination.Description = newDesc;
                        break;
                    }
                    else
                    {

                        DesignHelper.ApplyStyle(StyleText.ERROR, "Tres bien recommencer");
                        continue;
                    }
                }
                else
                {
                    DesignHelper.ApplyStyle(StyleText.ERROR, "Veuillez saisir à nouveau la Description");
                    continue;
                }
            } while (true);
            #endregion


            DesignHelper.ShowList(new List<Destination> { newDestination }, ["Id", "Country", "City", "Description"], StyleDisplayData.TABLE);
            DesignHelper.ApplyStyle(StyleText.CONFIRMATION, "\nConfirmez la nouvelle destination [O]ui [N]on ");
            if (NavigationHelper.ShouldContinue())
            {
                try
                {
                    await _destinationService.AddAsync(newDestination);
                    DesignHelper.ApplyStyle(StyleText.SUCCESS, "Destination sauvée avec succes");
                    DesignHelper.ApplyStyle(StyleText.INFO, "\\ Souhaitez vous ajouter une nouvelle destination [O]ui [N]on ");
                    if (NavigationHelper.ShouldContinue())
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }

                }
                catch (Exception ex)
                {
                    DesignHelper.ApplyStyle(StyleText.ERROR, $"Errro:{ex.Message}");
                    continue;
                }
            }
            else
            {
                continue;
            }
        } while (true);
        #endregion
    }
}