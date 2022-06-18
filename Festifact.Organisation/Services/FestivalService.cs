using Festifact.Organisation.Infrastructure;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace Festifact.Organisation.Services;

public class FestivalService
{
    private IConfiguration Configuration { get; }
    static HttpClient client;
    int OrganisationId = Globals.OrganisationId;

    public FestivalService(IConfiguration configuration)
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

    List<Festival> festivalList = new();
    public async Task<List<Festival>> GetFestivals()
    {
        var response = await client.GetAsync("/api/festival/organisation/" + OrganisationId.ToString());

        if (response.IsSuccessStatusCode)
        {
            festivalList = await response.Content.ReadFromJsonAsync<List<Festival>>();
        }
        return festivalList;
    }

    Random random = new();
    public async Task<Festival> AddFestival(Festival festival)
    {
        festival.FestivalId = random.Next(10, 10000);
        festival.OrganisatorId = OrganisationId;

        var json = JsonConvert.SerializeObject(festival);

        var content =
            new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/api/Festival", content);

        if (!response.IsSuccessStatusCode)
        {
            return festival;
        }
        else
        {
            return festival;
        }
    }
    public async Task<Festival> UpdateFestival(Festival festival)
    {

        var json = JsonConvert.SerializeObject(festival);

        var content =
            new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PutAsync("/api/Festival", content);

        if (!response.IsSuccessStatusCode)
        {
            return festival;
        }
        else
        {
            return festival;
        }
    }
}