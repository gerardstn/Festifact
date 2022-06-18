using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;


namespace Festifact.Visitor.Services;

public class ArtistService
{
    private IConfiguration Configuration { get; set; }
    static HttpClient client;

    public ArtistService(IConfiguration configuration)
    {
        Configuration = configuration;

        client = new HttpClient
            {
                BaseAddress = new Uri(configuration["Api:BaseUrl"])
            };
    }

    Artist artist = new();
    public async Task<Artist> GetShowArtist(int showId)
    {

        var response = await client.GetAsync("/api/artist/show/" + showId.ToString());

        if (response.IsSuccessStatusCode)
        {
            artist = await response.Content.ReadFromJsonAsync<Artist>();
        }

        return artist;
    }
}

