namespace Festifact.API.Models;

    public class Ticket
    {
        public int TicketId { get; set; }
        public int FestivalId { get; set; }
        public int VisitorId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double Price { get; set; }
    }

