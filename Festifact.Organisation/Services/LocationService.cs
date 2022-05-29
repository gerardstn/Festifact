using System.Net.Http.Json;


namespace Festifact.Organisation.Services;

public class LocationService
{

    HttpClient httpClient;
    public LocationService()
    {
        this.httpClient = new HttpClient();
    }


    List<Model.Location> locationList = new();
    public async Task<List<Model.Location>> GetLocations()
    {
        if (locationList?.Count > 0)
            return locationList;

        var response = await httpClient.GetAsync("https://festifactapi20220423103103.azurewebsites.net/api/Location");

        if (response.IsSuccessStatusCode)
        {
            locationList = await response.Content.ReadFromJsonAsync<List<Model.Location>>();
        }

        return locationList;
    }

}
