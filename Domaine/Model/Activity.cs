using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Model
{
    public class Activity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public Destination Destination { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
