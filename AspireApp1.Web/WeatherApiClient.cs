namespace AspireApp1.Web;

public class WeatherApiClient(HttpClient httpClient, ILogger<WeatherApiClient> logger)
{
    public async Task<WeatherForecast[]> GetWeatherAsync()
    {
        logger.LogInformation($"Called {nameof(GetWeatherAsync)} on {nameof(WeatherApiClient)}");
        return await httpClient.GetFromJsonAsync<WeatherForecast[]>("/weatherforecast") ?? [];
    }
}

public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
