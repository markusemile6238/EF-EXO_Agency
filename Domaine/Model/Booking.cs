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
        public string ClientName { get; set; } = string.Empty;
        public DateTime bookingAt { get; set; }

        public Activity? Activity;
    }
}
