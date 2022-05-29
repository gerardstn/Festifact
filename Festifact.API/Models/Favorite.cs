namespace Festifact.API.Models
{
    public class Favorite
    {
        public int FavoriteId { get; set; }
        public int? ShowId { get; set; }
        public int VisitorId { get; set; }
        public int? ArtistId { get; set; }
    }
}
