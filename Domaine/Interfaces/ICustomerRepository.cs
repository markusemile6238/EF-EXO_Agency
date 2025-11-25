using Domaine.Model;
using Domaine.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Interfaces
{
    public interface ICustomerRepository :IRepository<Customer>
    {

        public  Task<Customer> WithReturnAddAsync(Customer entity);
    }
}
