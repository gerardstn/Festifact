using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace Festifact.Organisation.Services;

public class ArtistService
{
    private IConfiguration Configuration { get; }

    static HttpClient client;
    public ArtistService(IConfiguration configuration)
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


    List<Artist> artistList = new();
    public async Task<List<Artist>> GetArtists()
    {
        if (artistList?.Count > 0)
            return artistList;

        var response = await client.GetAsync("/api/Artist");

        if (response.IsSuccessStatusCode)
        {
            artistList = await response.Content.ReadFromJsonAsync<List<Artist>>();
        }

        return artistList;
    }

    static Random random = new Random();
    public static async Task<Artist> AddArtist(string name, string genre,string description, string image, string countryOfOrigin, string type)
    {
        var artist = new Artist
        {
            Name = name,
            Genre = genre,
            Description = description,
            Image = image,
            CountryOrigin = countryOfOrigin,
            Type = type,
            ArtistId = random.Next(10, 10000)
        };

        var json = JsonConvert.SerializeObject(artist);

        var content = 
            new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/api/Artist", content);
        
        if (!response.IsSuccessStatusCode)
        {
            return artist;
        }
        else
        {
            return artist;
        }
    }
}
