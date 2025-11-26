namespace Domaine.Model.DTO
{
    public class ActivityDto
    {

        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? DestinationId { get; set; }

        public ActivityDto() { }

        public ActivityDto(string title, string description, decimal? price, int? destinationId)
        {
            Title = title;
            Description = description;
            Price = price;
            DestinationId = destinationId;
        }
    }

}
