using Domaine.Interfaces;
using Domaine.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ActivityRepository : IActivityRepository
    {

        private readonly AgDbContext _dbContext;

        public ActivityRepository(AgDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Activity entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Activity>> GetAllAsync()
        {
            return await _dbContext.Activities.ToListAsync();
        }

        public async Task<IEnumerable<Activity>> GetAllByDestinationId(int key)
        {
            return await _dbContext.Activities
                .Where(x => x.DestinationId == key)
                .ToListAsync();
        }

       

        public Task<Activity> UpdateAsync(Activity entity)
        {
            throw new NotImplementedException();
        }
   


        //async Task IRepository<Activity>.AddAsync(Activity entity)
        //{
        //    await _dbContext.Activities.AddAsync(entity);
        //    await _dbContext.SaveChangesAsync();
        //}

        //public async Task<IEnumerable<Activity>>  GetAllAsync()
        //{
        //    return await _dbContext.Activities.ToListAsync();
        //}
    }
}
