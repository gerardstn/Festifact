using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;

namespace Festifact.Visitor.Services;

public class RatingService
{
    private IConfiguration Configuration { get; }
    static HttpClient client;

    public RatingService(IConfiguration configuration)
    {
        Configuration = configuration;

        client = new HttpClient
        {
            BaseAddress = new Uri("https://festifactapi20220423103103.azurewebsites.net")
        };

    }

    Random random = new();
    public async Task<Rating> AddRating(Rating rating)
    {
        rating.RatingId = random.Next(10, 10000);

        var json = JsonConvert.SerializeObject(rating);

        var content =
            new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/api/rating", content);

        if (!response.IsSuccessStatusCode)
        {

            return rating;
        }
        else
        {
            return rating;
        }
    }

}

