using System.ComponentModel.DataAnnotations;

namespace Festifact.API.Models
{
    public class RoomReservation
    {
        public int RoomReservationId { get; set; }
        public string LocationId { get; set; }
        [Required]
        public int RoomId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

    }
}
