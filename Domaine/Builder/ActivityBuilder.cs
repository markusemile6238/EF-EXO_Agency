using Domaine.Interfaces.IActivity;
using Domaine.Model;
using Domaine.Model.DTO;

namespace Domaine.Builder
{
    public class ActivityBuilder : 
        IActivityTitle,
        IActivityDestination,
        IActivityPrice,
        IActivityDescription,
        IActivityBuild
    {

        public string Title { get; private set; }
        public string Description { get; private set; }
        public int DestinationId { get; private set; }
        public decimal Price { get; private set; }

        private  ActivityBuilder() { }

        public static IActivityTitle Create()
        {
            return new ActivityBuilder();
        }

        public IActivityDestination SetTitle(string title)
        {
            Title = title;
            return this;
        }

        public IActivityPrice SetDestination(int destinationId)
        {
            DestinationId = destinationId;
            return this;
        }
  
        public IActivityDescription SetPrice(decimal price)
        {
            price = price;
            return this;
        }

        public IActivityBuild SetDescription(string description) { 
            Description = description;
            return this;
            
        }

        public ActivityDto Build()
        {
            return new ActivityDto(Title,Description, Price, DestinationId);
        }

    }
}
