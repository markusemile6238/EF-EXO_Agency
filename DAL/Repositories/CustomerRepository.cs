using Domaine.Interfaces;
using Domaine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly AgDbContext _dbContext;

        public CustomerRepository(AgDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Customer entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async  Task<IEnumerable<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetByIdAsync(int key)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> WithReturnAddAsync(Customer entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
