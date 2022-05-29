using System.Net.Http.Json;


namespace Festifact.Organisation.Services;

public class MovieService
{

    HttpClient httpClient;
    public MovieService()
    {
        this.httpClient = new HttpClient();
    }


    List<Movie> movieList = new();
    public async Task<List<Movie>> GetMovies()
    {
        if (movieList?.Count > 0)
            return movieList;

        var response = await httpClient.GetAsync("https://festifactapi20220423103103.azurewebsites.net/api/Movie");

        if (response.IsSuccessStatusCode)
        {
            movieList = await response.Content.ReadFromJsonAsync<List<Movie>>();
        }

        return movieList;
    }

}
