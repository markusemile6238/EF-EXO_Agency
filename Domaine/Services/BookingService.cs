using Domaine.Interfaces;
using Domaine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Services
{
    public class BookingService
    {
        private readonly IBookingRepository _iBookingRepository;

        public BookingService(IBookingRepository iBookingRepository)
        {
            _iBookingRepository = iBookingRepository;
        }

        public async Task AddAsync(Booking booking)
        {

            try
            {
                await _iBookingRepository.AddAsync(booking);
                Console.WriteLine("Booking ajouté au contexte...");
              

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
