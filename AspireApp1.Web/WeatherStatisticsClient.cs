namespace AspireApp1.Web;
public class WeatherStatisticsClient(HttpClient httpClient, ILogger<WeatherStatisticsClient> logger)
{
    public async Task<WeatherForecast[]> Foobar()
    {
        logger.LogInformation($"Called {nameof(Foobar)} on {nameof(WeatherStatisticsClient)}");
        return await httpClient.GetFromJsonAsync<WeatherForecast[]>("/foobar") ?? [];
    }

    public async Task<string> SendWeatherDataHttpGet()
    {
        logger.LogInformation($"Called {nameof(SendWeatherDataHttpGet)} on {nameof(WeatherStatisticsClient)}");
        return await httpClient.GetStringAsync("/api/WeatherStatistics");
    }

}

