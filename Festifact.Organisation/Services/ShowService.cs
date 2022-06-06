using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace Festifact.Organisation.Services;

public class ShowService
{

    private IConfiguration Configuration { get; }
    static HttpClient client;
    public ShowService(IConfiguration configuration)
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


    List<Show> showList = new();
    public async Task<List<Show>> GetShows(int FestivalId)
    {

        var response = await client.GetAsync("/api/show/festival/" + FestivalId.ToString() + "");

        if (response.IsSuccessStatusCode)
        {
            showList = await response.Content.ReadFromJsonAsync<List<Show>>();
        }

        return showList;
    }

    Random random = new();
    public async Task<Show> AddShow(Show show)
    {
        show.ShowId = random.Next(10, 10000);

        var json = JsonConvert.SerializeObject(show);

        var content =
            new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/api/Show", content);

        if (!response.IsSuccessStatusCode)
        {
            return show;
        }
        else
        {
            return show;
        }
    }

}
