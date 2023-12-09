namespace AspireApp1.ApiService.WeatherStatisticsClient
{
    public class WeatherStatisticsClient(HttpClient httpClient, ILogger<WeatherStatisticsClient> logger)
    {
        public async Task SendWeatherDataHttpGet()
        {
            logger.LogInformation($"Called {nameof(SendWeatherDataHttpGet)} on {nameof(WeatherStatisticsClient)}");
            _ = await httpClient.GetAsync("/api/WeatherStatisticsGet");
            return;
        }

        public async Task SendWeatherDataHttpPost()
        {
            logger.LogInformation($"Called {nameof(SendWeatherDataHttpGet)} on {nameof(WeatherStatisticsClient)}");
            StringContent stringContent = new StringContent(Guid.NewGuid().ToString());
            _ = await httpClient.PostAsync("/api/WeatherStatisticsPost", stringContent);
            return;
        }
    }
}