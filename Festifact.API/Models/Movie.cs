using System.ComponentModel.DataAnnotations;

namespace Festifact.API.Models
{
    public class Movie
    {
        [Required]
        public int MovieId { get; set; }
        public string Actors { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseYear { get; set; }
        public string CountryOrigin { get; set; }
    }
}
