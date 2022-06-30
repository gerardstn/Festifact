using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;


namespace Festifact.Visitor.Services;

    public class ShowService
    {
    private IConfiguration Configuration { get; }
    static HttpClient client;

    public ShowService(IConfiguration configuration)
    {
            client = new HttpClient
            {
                BaseAddress = new Uri("https://festifactapi20220423103103.azurewebsites.net")
            };

        Configuration = configuration;
    }

    List<Show> showList = new();
    public async Task<List<Show>> GetShows(int FestivalId)
    {

        var response = await client.GetAsync("/api/show/festival/" + FestivalId.ToString());

        if (response.IsSuccessStatusCode)
        {
            showList = await response.Content.ReadFromJsonAsync<List<Show>>();
        }

        return showList;
    }

    Show show = new();
    public async Task<Show> GetShowById(int showId)
    {

        var response = await client.GetAsync("/api/show/" + showId.ToString());

        if (response.IsSuccessStatusCode)
        {
            show = await response.Content.ReadFromJsonAsync<Show>();
        }

        return show;
    }
}
