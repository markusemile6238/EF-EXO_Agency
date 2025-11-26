using Domaine.Interfaces.IBooking;
using Domaine.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine.Builder
{
    public class BookingBuilder : ISetCustomerId, ISetReservationDate, ISetDestinationId, ISetActivity, IWithAnotherActivity, IBuildBooking
    {

        public int CustomerId { get;  private set; }
        public DateTime BookingDate { get; private set; }
        public int DestinationId { get; private set; }
        public ICollection<Model.Activity> Activities { get; private set; } 

        public int DestinationID {  get; private set; }

        private BookingBuilder(){
            Activities = new List<Model.Activity>();

        }

        public static ISetCustomerId Create()
        {
            return new BookingBuilder();
        }

        public ISetReservationDate SetCustomerId(int customerId)
        {
            CustomerId = customerId;
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
            return SetActivity(activity);
        }

 
       IBuildBooking ISetActivity.Build()  // implemntation de IBuilderBokking de setActivity
        {
            if(Activities != null)
            {
                Activities = Activities.ToList();
            }
            return this;
        }

        IBuildBooking IWithAnotherActivity.Build()
        {
            return this;
        }

        public Booking  Build()
        {
            if(CustomerId <= 0)
                throw new InvalidOperationException("CustomerId must be set");

            if (DestinationId <= 0)
                throw new InvalidOperationException("DestinationId must be set");

            var booking = new Booking
            {              
                CustomerId = this.CustomerId,
                BookingDate = this.BookingDate,
            };

            // Ajouter les activités
            foreach (var activity in Activities)
            {
                booking.Activities.Add(activity);
            }

            return booking;
        }

        public IBuildBooking SetActivities(ICollection<Model.Activity> activities)
        {
            if (activities != null)
            {
                foreach(var actvity in Activities.Where(a=> a != null))
                    Activities = activities.ToList();
            }
           return this;
        }
    }
}
