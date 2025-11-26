using Domaine.Interfaces;
using Domaine.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly AgDbContext _context;

        public DestinationRepository(AgDbContext context)
        {
            _context = context;
        }

        public async  Task AddAsync(Destination entity)
        {
            await _context.Destinations.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async  Task<IEnumerable<Destination>> GetAllAsync()
        {
            try
            {
                if(_context == null)
                {
                    Console.WriteLine("_context null");
                    return new List<Destination>();
                }
                if (_context.Destinations == null)
                {
                    Console.WriteLine("_context.Destinations est null!");
                    return new List<Destination>();
                }

                    var result =  await _context.Destinations.ToListAsync();
                    return result ?? new List<Destination>();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur dans GetAllAsync: {ex.Message}");
                return new List<Destination>();
            }
            
        }

        public Task<Destination> GetByIdAsync(int key)
        {
            throw new NotImplementedException();
        }
    }
}
