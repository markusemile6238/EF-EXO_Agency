using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Model
{
    public class Destination
    {

        public int Id { get; set; }
        public required string Country { get; set; }
        public required string City { get; set; }
        public required string Description { get; set; }

        public ICollection<Activity> Activities { get; set; } = new List<Activity>();


    
    }


}
