using System.Net.Http.Json;


namespace Festifact.Visitor.Services;

    public class FestivalService
    {

    HttpClient httpClient;
    public FestivalService()
    {
        this.httpClient = new HttpClient();
    }

    List<Festival> festivalList = new();
    public async Task<List<Festival>> GetFestivals()
    {
        if (festivalList?.Count > 0)
            return festivalList;

        var response = await httpClient.GetAsync("https://festifactapi20220423103103.azurewebsites.net/api/festival");

        if (response.IsSuccessStatusCode)
        {
            festivalList = await response.Content.ReadFromJsonAsync<List<Festival>>();
        }

        return festivalList;
    }

    List<Festival> festivalSearchResult = new();
    public async Task<List<Festival>> SearchFestivals(string Type, string Genre, string Age, string Location, string Date)
    {
        if (festivalSearchResult?.Count > 0)
            return festivalSearchResult;

        
        var response = await httpClient.GetAsync("https://festifactapi20220423103103.azurewebsites.net/api/festival/search?Type="+Type+"&Genre="+Genre+"&Age="+Age+"&Location="+Location+"&Date="+Date+"");

        if (response.IsSuccessStatusCode)
        {
            festivalSearchResult = await response.Content.ReadFromJsonAsync<List<Festival>>();
        }
        return festivalSearchResult;
    }
}
