using Domaine.Interfaces.IBooking;
using Domaine.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Builder
{
    public class BookingBuilder : ISetName, ISetReservationDate, ISetDestinationId, ISetActivity, IWithAnotherActivity, IBuildBooking
    {

        public int Id { get;  private set; }
        public DateTime BookingDate { get; private set; }
        public int CustomerId { get; private set; }
        public ICollection<Model.Activity> Activities { get; private set; }

        public int DestinationID {  get; private set; }

        private BookingBuilder(){ }

        public static ISetName Creater()
        {
            return new BookingBuilder();
        }

        public ISetReservationDate SetName(int id)
        {
            Id = id;
            return this;
        }

        public ISetDestinationId SetReservationDate(DateTime date)
        {
            BookingDate = date;
            return this;
        }

        public ISetActivity SetDestinationId(int destinationId)
        {
           DestinationID = destinationId;
            return this;
        }

        public IWithAnotherActivity SetActivity(Model.Activity activity)
        {
            if (activity != null) Activities.Add(activity);
            return this;
        }

        IWithAnotherActivity IWithAnotherActivity.SetActivity(Model.Activity activity) // implemntation de IWithAnotherActivity de setActivity
        {
            if (activity != null) Activities.Add(activity);
            return this;
        }

        IBuildBooking ISetActivity.Build()  // implemntation de IBuilderBokking de setActivity
        {
            return this;
        }

        IBuildBooking IWithAnotherActivity.Build()
        {
            return this;
        }

        public Booking  Build()
        {
            var booking = new Booking
            {
                Id = this.Id,
                BookingDate = this.BookingDate,
                CustomerId = this.CustomerId,
            };

            // Ajouter les activités
            foreach (var activity in Activities)
            {
                booking.Activities.Add(activity);
            }

            return booking;
        }
    }
}
