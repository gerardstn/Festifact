using System.ComponentModel.DataAnnotations;

namespace Festifact.API.Models
{
    public class Artist
    {
        [Required]
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string CountryOrigin { get; set; }
        public string Type { get; set; }
    }
}
