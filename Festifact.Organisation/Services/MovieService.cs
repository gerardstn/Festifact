using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace Festifact.Organisation.Services;

public class MovieService
{
    private IConfiguration Configuration { get; }
    static HttpClient client;
    public MovieService(IConfiguration configuration)
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

    List<Movie> movieList = new();
    public async Task<List<Movie>> GetMovies()
    {

        var response = await client.GetAsync("/api/Movie");

        if (response.IsSuccessStatusCode)
        {
            movieList = await response.Content.ReadFromJsonAsync<List<Movie>>();
        }

        return movieList;
    }

    Random random = new();
    public async Task<Movie> AddMovie(Movie movie)
    {
        movie.MovieId = random.Next(10, 10000);

        var json = JsonConvert.SerializeObject(movie);

        var content =
            new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/api/Movie", content);

        if (!response.IsSuccessStatusCode)
        {
            return movie;
        }
        else
        {
            return movie;
        }
    }
    public async Task<Movie> UpdateMovie(Movie movie)
    {

        var json = JsonConvert.SerializeObject(movie);

        var content =
            new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PutAsync("/api/Movie", content);

        if (!response.IsSuccessStatusCode)
        {
            return movie;
        }
        else
        {
            return movie;
        }
    }
}