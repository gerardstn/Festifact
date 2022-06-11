namespace Festifact.Organisation.Model;

    public class RoomReservation
{
    public int RoomReservationId { get; set; }
    public int RoomId { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }

}