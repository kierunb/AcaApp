using AcaApp.RazorWeb.Clients;
using AcaApp.RazorWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AcaApp.RazorWeb.Pages;

public class WeatherModel : PageModel
{
    public WeatherForecast[] Forecasts { get; set; }

    public async Task OnGetAsync([FromServices] WeatherClient client)
    {
        Forecasts = await client.GetWeatherAsync();
    }
}
