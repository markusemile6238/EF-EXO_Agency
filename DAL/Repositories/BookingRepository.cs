using Domaine.Interfaces;
using Domaine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AgDbContext _dbContext;

        public BookingRepository(AgDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Booking booking)
        {
            try
            {
                Console.WriteLine("=== DEBUG BookingService ===");
                Console.WriteLine($"Booking CustomerId: {booking.CustomerId}");
                Console.WriteLine($"Booking Date: {booking.BookingDate}");
                Console.WriteLine($"Activities Count: {booking.Activities?.Count}");


                await _dbContext.AddAsync(booking);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // ✅ AFFICHEZ L'EXCEPTION INTERNE
                Console.WriteLine("❌ ERREUR EXTERNE: " + ex.Message);

                if (ex.InnerException != null)
                {
                    Console.WriteLine("🎯 ERREUR INTERNE: " + ex.InnerException.Message);
                    Console.WriteLine("📌 TYPE: " + ex.InnerException.GetType().Name);
                    Console.WriteLine("🔍 STACKTRACE: " + ex.InnerException.StackTrace);

                    // Si c'est une DbUpdateException, allez encore plus profond
                    if (ex.InnerException.InnerException != null)
                    {
                        Console.WriteLine("🎯 ERREUR PLUS INTERNE: " + ex.InnerException.InnerException.Message);
                    }
                }
            }
        }

        public Task<IEnumerable<Booking>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
