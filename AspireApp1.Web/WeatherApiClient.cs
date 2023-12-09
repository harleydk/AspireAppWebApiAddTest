namespace AspireApp1.Web;

public class WeatherApiClient(HttpClient httpClient, ILogger<WeatherApiClient> logger)
{
    public async Task<WeatherForecast[]> GetWeatherAsyncHttpGet()
    {
        logger.LogInformation($"Called {nameof(GetWeatherAsyncHttpGet)} on {nameof(WeatherApiClient)}");
        return await httpClient.GetFromJsonAsync<WeatherForecast[]>("/weatherforecastGet") ?? [];
    }

    public async Task<WeatherForecast[]> GetWeatherAsyncHttpPost()
    {
        logger.LogInformation($"Called {nameof(GetWeatherAsyncHttpGet)} on {nameof(WeatherApiClient)}");
        return await httpClient.GetFromJsonAsync<WeatherForecast[]>("/weatherforecastPost") ?? [];
    }
}

public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
