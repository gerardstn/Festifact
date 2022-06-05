using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;


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
        if (locationList?.Count > 0)
            return locationList;

        var response = await client.GetAsync("/api/Location");

        if (response.IsSuccessStatusCode)
        {
            locationList = await response.Content.ReadFromJsonAsync<List<Model.Location>>();
        }

        return locationList;
    }

}
