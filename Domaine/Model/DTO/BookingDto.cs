using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Model.DTO
{
    public class BookingDto
    {
        public DateTime BookingDate { get; set; }
        public int CustomerId { get; set; }
        public List<Activity> Activities { get; set; }

        public BookingDto()
        {
            Activities = new List<Activity>();
        }

    }

}
