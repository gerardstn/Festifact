using System.Net.Http.Json;


namespace Festifact.Organisation.Services;

public class ArtistService
{

    HttpClient httpClient;
    public ArtistService()
    {
        this.httpClient = new HttpClient();
    }


    List<Artist> artistList = new();
    public async Task<List<Artist>> GetArtists()
    {
        if (artistList?.Count > 0)
            return artistList;

        var response = await httpClient.GetAsync("https://festifactapi20220423103103.azurewebsites.net/api/Artist");

        if (response.IsSuccessStatusCode)
        {
            artistList = await response.Content.ReadFromJsonAsync<List<Artist>>();
        }

        return artistList;
    }

}
