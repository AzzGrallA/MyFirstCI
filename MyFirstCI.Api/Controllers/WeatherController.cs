using Microsoft.AspNetCore.Mvc;

namespace MyFirstCI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    [HttpGet("WeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55)
            ))
            .ToArray();
        return forecast;
    }
}

public record WeatherForecast(DateOnly Date, int TemperatureC)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}