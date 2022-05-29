namespace Festifact.API.Models
{
    public class Rating
    {
        public int RatingId { get; set; }
        public string? Message { get; set; }
        public int Stars { get; set; }
        public int ShowId { get; set; }
        public int VisitorId { get; set; }
    }
}
