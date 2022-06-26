namespace Festifact.API.Models;

    public class Rating
    {
        public int RatingId { get; set; }
        public string? Message { get; set; }
        public int Stars { get; set; }
        public int FestivalId { get; set; }
        public int VisitorId { get; set; }
    }

