using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace Festifact.Organisation.Services;

public class FestivalService
{
    private IConfiguration Configuration { get; }
    static HttpClient client;
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
    public async Task<List<Festival>> GetFestivals(int OrganisationId)
    {
        if (festivalList?.Count > 0)
            return festivalList;

        var response = await client.GetAsync("/api/festival/organisation/" + OrganisationId.ToString() + "");

        if (response.IsSuccessStatusCode)
        {
            festivalList = await response.Content.ReadFromJsonAsync<List<Festival>>();
        }

        return festivalList;
    }

}
