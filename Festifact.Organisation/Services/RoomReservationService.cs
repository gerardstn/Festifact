using Festifact.Organisation.Infrastructure;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace Festifact.Organisation.Services;

public class RoomReservationService
{
    private IConfiguration Configuration { get; }
    static HttpClient client;
    int OrganisationId = Globals.OrganisationId;

    public RoomReservationService(IConfiguration configuration)
    {
        try
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(configuration["Api:BaseUrl"])
            };
        }
        catch
        {

        }
        Configuration = configuration;
    }


    List<RoomReservation> roomReservationList = new();
    public async Task<List<RoomReservation>> GetRoomReservations(int RoomId)
    {

        var response = await client.GetAsync("/api/roomReservation/room/"+ RoomId.ToString());

        if (response.IsSuccessStatusCode)
        {
            roomReservationList = await response.Content.ReadFromJsonAsync<List<RoomReservation>>();
        }

        return roomReservationList;
    }



    Random random = new();
    public async Task<RoomReservation> AddRoomReservation(RoomReservation roomReservation)
    {
        roomReservation.RoomReservationId = random.Next(10, 10000);

        var json = JsonConvert.SerializeObject(roomReservation);

        var content =
            new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/api/RoomReservation", content);

        if (!response.IsSuccessStatusCode)
        {
            return roomReservation;
        }
        else
        {
            return roomReservation;
        }
    }
}