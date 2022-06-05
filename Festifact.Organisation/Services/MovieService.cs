using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;


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
        if (movieList?.Count > 0)
            return movieList;

        var response = await client.GetAsync("/api/Movie");

        if (response.IsSuccessStatusCode)
        {
            movieList = await response.Content.ReadFromJsonAsync<List<Movie>>();
        }

        return movieList;
    }

}
