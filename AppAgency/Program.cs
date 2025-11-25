
using AppAgency.Menu;
using DAL;
using DAL.Repositories;
using Domaine.Interfaces;
using Domaine.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;



class Program
{
    private static IServiceProvider _services;
    private static bool runner = true;
    
    static async Task Main(string[] args)
    {



        // injetion des dépendance
        SetupDI();
        await ShowMenu();

    }

    static void SetupDI()
    {
        var services = new ServiceCollection();
        services.AddDbContext<AgDbContext>(options => options.UseSqlServer("Server=GOS-VDI509\\TFTIC;Initial Catalog=ExoAgency;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));

        // Repository
        services.AddScoped<IDestinationRepository, DestinationRepository>();
        services.AddScoped<IActivityRepository, ActivityRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        // Services
        services.AddScoped<DestinationService>();
        services.AddScoped<ActivityService>();
        services.AddScoped<CustomerService>();
        services.AddScoped<DestinationMenu>();
        services.AddScoped<ActivityMenu>();
        services.AddScoped<BookingMenu>();

        _services = services.BuildServiceProvider();
    }

    static async Task ShowMenu()
    {
        while (runner)
        {
            Console.Clear();
            string menu = """
                - - - - - - - - - - - - - - - -
                - - -     M E N U     - - - - -
                - - - - - - - - - - - - - - - -
                - [1] Ajouter une destination -
                - - - - - - - - - - - - - - - -
                - [2] Ajouter une activitée   -
                - - - - - - - - - - - - - - - -
                - [3] Liste des destinations  -
                - - - - - - - - - - - - - - - -
                - [4] Faire une reservation   -
                - - - - - - - - - - - - - - - -
                - - - - - - - - - - - - - - - -
                - [x] Sortir du programme     -
                - - - - - - - - - - - - - - - -
            """;

            Console.WriteLine(menu);
            var key = Console.ReadKey(true);
            Console.WriteLine();
                      
            var serviceDes = _services.GetRequiredService<DestinationMenu>();
            var serviceActiv = _services.GetRequiredService<ActivityMenu>();
            var serviceBooking = _services.GetRequiredService<BookingMenu>();
            
            switch (key.Key)
            {
                case ConsoleKey.D1 or ConsoleKey.NumPad1:
                    await serviceDes.AddDestination();
                    break;
                case ConsoleKey.D2 or ConsoleKey.NumPad2:
                    await serviceActiv.AddActivity();
                    break;
                case ConsoleKey.D3 or ConsoleKey.NumPad3:
                    await serviceDes.ShowAll();
                    break;
                case ConsoleKey.D4 or ConsoleKey.NumPad4:
                    await serviceBooking.BookingATrip();
                    break;

                case ConsoleKey.X:
                    runner = false;
                    break;
                    }
        }
    }

}