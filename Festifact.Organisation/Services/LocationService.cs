using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace Festifact.Organisation.Services;

public class LocationService
{
    private IConfiguration Configuration { get; }
    static HttpClient client;
    public LocationService(IConfiguration configuration)
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


    List<Model.Location> locationList = new();
    public async Task<List<Model.Location>> GetLocations()
    {


        var response = await client.GetAsync("/api/Location");

        if (response.IsSuccessStatusCode)
        {
            locationList = await response.Content.ReadFromJsonAsync<List<Model.Location>>();
        }

        return locationList;
    }

    Random random = new();
    public async Task<Model.Location> AddLocation(Model.Location location)
    {
        location.LocationId = random.Next(10, 10000);

        var json = JsonConvert.SerializeObject(location);

        var content =
            new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/api/Location", content);

        if (!response.IsSuccessStatusCode)
        {
            return location;
        }
        else
        {
            return location;
        }
    }
}
