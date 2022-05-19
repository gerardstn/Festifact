using System.ComponentModel.DataAnnotations;

namespace Festifact.API.Models;

public class Festival
{
    [Required]
    public int FestivalId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Banner { get; set; }
    public int TicketsAvailable { get; set; }
    [Required]
    public int TicketsLimit { get; set; }
    public string? Type { get; set; }
    public string? Genre { get; set; }
    public string? Location { get; set; }
    public string? AgeCatagory { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    [Required]
    public int OrganisatorId { get; set; }
}