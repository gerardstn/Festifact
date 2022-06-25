using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;

namespace Festifact.Visitor.Services;


public class VisitorService
{
    private IConfiguration Configuration { get; set; }
    static HttpClient client;

    public VisitorService(IConfiguration configuration)
    {
        Configuration = configuration;

        client = new HttpClient
        {
            BaseAddress = new Uri(configuration["Api:BaseUrl"])
        };  
        
    }


    Random random = new();
    public async Task<Model.Visitor> AddVisitor(Model.Visitor visitor)
    {
        visitor.VisitorId = random.Next(10, 10000);

        var json = JsonConvert.SerializeObject(visitor);

        var content =
            new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/api/Visitor", content);

        if (!response.IsSuccessStatusCode)
        {

            return visitor;
        }
        else
        {
            return visitor;
        }
    }

    public async Task<Model.Visitor> UpdateVisitor(Model.Visitor visitor)
    {

        var json = JsonConvert.SerializeObject(visitor);

        var content =
            new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PutAsync("/api/Visitor", content);

        if (!response.IsSuccessStatusCode)
        {

            return visitor;
        }
        else
        {
            return visitor;
        }
    }
    Model.Visitor visitor = new();
    public async Task<Model.Visitor> GetVisitor(int VisitorId)
    {

        var response = await client.GetAsync("/api/visitor/" + VisitorId.ToString());

        if (response.IsSuccessStatusCode)
        {
            visitor = await response.Content.ReadFromJsonAsync<Model.Visitor>();
        }

        return visitor;
    }

    Model.Visitor visitorLogin = new();
    public async Task<Model.Visitor> GetVisitorLogin(string email, string password)
    {
        var response = await client.GetAsync("/api/visitor/login/?Email=" + email +"&Password="+ password);

        if (response.IsSuccessStatusCode)
        {
            visitorLogin = await response.Content.ReadFromJsonAsync<Model.Visitor>();
        }

        return visitorLogin;
    }



}

