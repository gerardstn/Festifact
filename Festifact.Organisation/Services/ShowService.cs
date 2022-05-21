using System.Net.Http.Json;


namespace Festifact.Organisation.Services;

public class ShowService
{

    HttpClient httpClient;
    public ShowService()
    {
        this.httpClient = new HttpClient();
    }


    List<Show> showList = new();
    public async Task<List<Show>> GetShows(int FestivalId)
    {
        if (showList?.Count > 0)
            return showList;

        var response = await httpClient.GetAsync("https://festifactapi20220423103103.azurewebsites.net/api/festival/" + FestivalId.ToString() + "/show");

        if (response.IsSuccessStatusCode)
        {
            showList = await response.Content.ReadFromJsonAsync<List<Show>>();
        }

        return showList;
    }


}
