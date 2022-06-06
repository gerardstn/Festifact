using Festifact.Organisation.Infrastructure;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace Festifact.Organisation.Services;

public class RoomService
{
    private IConfiguration Configuration { get; }
    static HttpClient client;
    int OrganisationId = Globals.OrganisationId;

    public RoomService(IConfiguration configuration)
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


    List<Room> roomList = new();
    public async Task<List<Room>> GetRooms()
    {

        var response = await client.GetAsync("/api/room");

        if (response.IsSuccessStatusCode)
        {
            roomList = await response.Content.ReadFromJsonAsync<List<Room>>();
        }

        return roomList;
    }

    Random random = new();
    public async Task<Room> AddRoom(Room room)
    {
        room.RoomId = random.Next(10, 10000);

        var json = JsonConvert.SerializeObject(room);

        var content =
            new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/api/Room", content);

        if (!response.IsSuccessStatusCode)
        {
            return room;
        }
        else
        {
            return room;
        }
    }
}