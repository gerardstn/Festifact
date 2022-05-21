namespace Festifact.Visitor.Model;

public class Show
{
    public int ShowId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int FestivalId { get; set; }
    public int ArtistId { get; set; }
    public int MovieId { get; set; }
    public int RoomReservationId { get; set; }
    public int FestivalDay { get; set; }


}

