using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Model.DTO
{
    public class CustomerDto
    {
        public string Name { get; set; }

        public CustomerDto() { }

        public CustomerDto(string name)
        {
            Name = name;
        }


    }
}
