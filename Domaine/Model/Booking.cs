using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();
    }
}
