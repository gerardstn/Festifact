namespace Festifact.Visitor.Model;

    public class Festival
    {
    public int FestivalId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Banner { get; set; }
    public int TicketsAvailable { get; set; }
    public int TicketsLimit { get; set; }
    public string Type { get; set; }
    public string Location { get; set; }
    public string Genre { get; set; }
    public string AgeCatagory { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}