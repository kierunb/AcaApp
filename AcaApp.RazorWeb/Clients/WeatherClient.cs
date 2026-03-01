using AcaApp.RazorWeb.Models;
using System.Text.Json;

namespace AcaApp.RazorWeb.Clients;

public class WeatherClient
{
    private readonly JsonSerializerOptions _options = new JsonSerializerOptions()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };

    private readonly HttpClient client;

    public WeatherClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<WeatherForecast[]> GetWeatherAsync()
    {
        return await this.client.GetFromJsonAsync<WeatherForecast[]>("/weatherforecast");
    }
}
