using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;

namespace Festifact.Visitor.Services;

public class TicketService
{

    private IConfiguration Configuration { get; }
    static HttpClient client;

    public TicketService(IConfiguration configuration)
    {
        Configuration = configuration;

        client = new HttpClient
        {
            BaseAddress = new Uri(configuration["Api:BaseUrl"])
        };

    }


    Random random = new();
    public async Task<Ticket> AddTicket(Ticket ticket, Festival festival)
    {

        ticket.TicketId = random.Next(10, 10000);

        var json = JsonConvert.SerializeObject(ticket);

        var content =
            new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/api/ticket", content);

        if (!response.IsSuccessStatusCode)
        {

            return ticket;
        }
        else
        {
            await UpdateFestival(festival);
            return ticket;
        }
    }

    public async Task<Festival> UpdateFestival(Festival festival)
    {
        festival.TicketsAvailable--;
        var json = JsonConvert.SerializeObject(festival);

        var content =
            new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PutAsync("/api/Festival", content);

        if (!response.IsSuccessStatusCode)
        {
            return festival;
        }
        else
        {
            return festival;
        }
    }

    List<Ticket> ticketList = new();
    public async Task<List<Ticket>> GetTickets()
    {

        var response = await client.GetAsync("/api/ticket/visitor/" + Preferences.Get("VisitorId", 0));

        if (response.IsSuccessStatusCode)
        {
            ticketList = await response.Content.ReadFromJsonAsync<List<Ticket>>();
        }

        return ticketList;
    }

}
