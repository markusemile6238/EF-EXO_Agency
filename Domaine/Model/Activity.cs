namespace Domaine.Model
{
    public class Activity
    {

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int DestinationId { get; set; }  
 

        public Destination? Destination { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        

        public Activity(string title, string description, decimal price,int destinationId)
        {
            Title = title;
            Description = description;
            Price = price;
            DestinationId = destinationId;
        }
    }





}
