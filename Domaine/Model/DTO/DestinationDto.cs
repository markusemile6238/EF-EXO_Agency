using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Model.DTO
{
    public class DestinationDto
    {

        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Description { get; set; }

        public DestinationDto(){}

        public DestinationDto(int id, string country, string city, string description)
        {
            Id = id;
            Country = country;
            City = city;
            Description = description;
        }

        public DestinationDto( string country, string city, string description)
        {
        
            Country = country;
            City = city;
            Description = description;
        }
    }
}
