using AspireApp1.ApiService.WeatherStatisticsClient;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

builder.Services.AddHttpClient<WeatherStatisticsClient>(client => client.BaseAddress = new("http://weatherstatisticsservice"));

WebApplication app = builder.Build();

ILogger logger = app.Logger;

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

string[] summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};


app.MapGet("/weatherforecastGet", async () =>
{
    WeatherForecast[] forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();

    WeatherStatisticsClient weatherStatisticsClient = app.Services.GetRequiredService<WeatherStatisticsClient>();
    await weatherStatisticsClient.SendWeatherDataHttpGet();

    logger.LogInformation($"Returning weather forecast");
    return forecast;
});


app.MapGet("/weatherforecastPost", async () =>
{
    WeatherForecast[] forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();

    WeatherStatisticsClient weatherStatisticsClient = app.Services.GetRequiredService<WeatherStatisticsClient>();
    await weatherStatisticsClient.SendWeatherDataHttpPost();

    logger.LogInformation($"Returning weather forecast");
    return forecast;
});


app.MapDefaultEndpoints();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
