using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Booking>? Bokkings { get; set; }
        public ICollection<Activity>? Activities { get; set; }

        


    }
}
