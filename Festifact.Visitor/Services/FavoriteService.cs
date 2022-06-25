using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;

namespace Festifact.Visitor.Services;


public class FavoriteService
{
    private IConfiguration Configuration { get; set; }
    static HttpClient client;

    public FavoriteService(IConfiguration configuration)
    {
        Configuration = configuration;

        client = new HttpClient
        {
            BaseAddress = new Uri(configuration["Api:BaseUrl"])
        };  
        
    }

    Random random = new();
    public async Task<Favorite> AddShowFavorite(int showId)
    {
        Favorite favorite = new Favorite();
        favorite.FavoriteId = random.Next(10, 10000);
        favorite.ShowId = showId;
        favorite.VisitorId = Preferences.Get("VisitorId", 0);

        /* get favorite with same show id, if exist return exist ofzo..*/

        var json = JsonConvert.SerializeObject(favorite);

        var content =
            new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/api/favorite", content);

        if (!response.IsSuccessStatusCode)
        {

            return null;
        }
        else
        {
            return favorite;
        }
    }
    public async Task<Favorite> AddArtistFavorite(int artistId)
    {
        Favorite favorite = new Favorite();
        favorite.FavoriteId = random.Next(10, 10000);
        favorite.ArtistId = artistId;
        favorite.VisitorId = Preferences.Get("VisitorId", 0);

        /* get favorite with same show id, if exist return exist ofzo..*/

        var json = JsonConvert.SerializeObject(favorite);

        var content =
            new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/api/favorite", content);

        if (!response.IsSuccessStatusCode)
        {

            return null;
        }
        else
        {
            return favorite;
        }
    }

    List<Favorite> favoriteShowsList = new();
    public async Task<List<Favorite>> GetFavoriteShows()
    {

        var response = await client.GetAsync("/api/favorite/show/" + Preferences.Get("VisitorId", 0));

        if (response.IsSuccessStatusCode)
        {
            favoriteShowsList = await response.Content.ReadFromJsonAsync<List<Favorite>>();
        }

        return favoriteShowsList;
    }

    List<Favorite> favoriteArtistsList = new();
    public async Task<List<Favorite>> GetFavoriteArtists()
    {
        var vistiorId = Preferences.Get("VisitorId", 0);

        var response = await client.GetAsync("/api/favorite/artist/" + vistiorId);

        if (response.IsSuccessStatusCode)
        {
            favoriteArtistsList = await response.Content.ReadFromJsonAsync<List<Favorite>>();
        }

        return favoriteArtistsList;
    }

    public async Task<HttpResponseMessage> RemoveFavorite(Favorite favorite)
    {
        var response = await client.DeleteAsync("/api/favorite/" + favorite.FavoriteId);
        return response;
    }
}

