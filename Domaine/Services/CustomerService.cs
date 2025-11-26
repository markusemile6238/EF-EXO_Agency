using Domaine.Interfaces;
using Domaine.Model;
using Domaine.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task AddAsync(Customer customer)
        {
            try
            {

                if (String.IsNullOrEmpty(customer.Name)) throw new Exception("Name is require");
                Customer nc = new Customer(name: customer.Name);
                await _customerRepository.AddAsync(nc);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Customer> WithReturnAddAsyn(Customer customer)
        {
            try
            {
                Console.WriteLine($"CustomerService=>{customer.Name}");
                if (String.IsNullOrEmpty(customer.Name)) throw new Exception("Name is require");

                var nc = new Customer(name: customer.Name);
                return await _customerRepository.WithReturnAddAsync(nc);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur dans WithReturnAddAsyn: {ex.Message}");
                throw;
            }
        }




    }
}
