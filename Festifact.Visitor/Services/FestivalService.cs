using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;


namespace Festifact.Visitor.Services;

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
    public async Task<List<Festival>> GetFestivals()
    {
        if (festivalList?.Count > 0)
            return festivalList;

        var response = await client.GetAsync("/api/festival");

        if (response.IsSuccessStatusCode)
        {
            festivalList = await response.Content.ReadFromJsonAsync<List<Festival>>();
        }

        return festivalList;
    }

    List<Festival> festivalSearchResult = new();
    public async Task<List<Festival>> SearchFestivals(string Type, string Genre, string Age, string Location, DateTime Date)
    {
        var response = await client.GetAsync("/api/festival/search?Type="+Type+"&Genre="+Genre+"&Age="+Age+"&Location="+Location+"&Date="+Date.Year+"-"+Date.Month+"-"+Date.Day+"");

        if (response.IsSuccessStatusCode)
        {
            festivalSearchResult = await response.Content.ReadFromJsonAsync<List<Festival>>();
        }
        return festivalSearchResult;
    }



    Festival festival = new();
    public async Task<Festival> GetFestivalById(int festivalId)
    {

        var response = await client.GetAsync("/api/festival/" + festivalId.ToString());

        if (response.IsSuccessStatusCode)
        {
            festival = await response.Content.ReadFromJsonAsync<Festival>();
        }

        return festival;
    }

}
