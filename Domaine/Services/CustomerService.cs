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

        public async Task AddAsync(CustomerDto customerDto)
        {
            if (String.IsNullOrEmpty(customerDto.Name)) throw new Exception("Name is require");
            Customer nc = new Customer(name:customerDto.Name);
            await _customerRepository.AddAsync(nc);
        }

        public async Task<Customer> WithReturnAddAsyn(CustomerDto customerDto)
        {
            try
            {
                Console.WriteLine($"CustomerService=>{customerDto.Name}");
                if (String.IsNullOrEmpty(customerDto.Name)) throw new Exception("Name is require");

                var nc = new Customer(name: customerDto.Name);
                return await _customerRepository.WithReturnAddAsync(nc);
               
            }catch(Exception ex)
            {
                Console.WriteLine($"Erreur dans WithReturnAddAsyn: {ex.Message}");
                throw;
            }
        }


       

    }
}
