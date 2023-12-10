using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class WeatherStatisticsClient(IConnection rabbitMqConnection, HttpClient httpClient, ILogger<WeatherStatisticsClient> logger)
{
    private const string queueName = "randomqueue";
    public async Task LogWeatherStats()
    {
        logger.LogInformation("Logging stats");

        //WeatherForecast[] forecast = await httpClient.GetFromJsonAsync<WeatherForecast[]>("/foobar");
        //int allTemps = forecast.Sum(x => x.TemperatureC);

        //IModel _messageChannel = rabbitMqConnection.CreateModel();
        //_messageChannel.QueueDeclare(queueName, exclusive: false);

        //EventingBasicConsumer consumer = new EventingBasicConsumer(_messageChannel);
        //consumer.Received += Consumer_Received;

        //_messageChannel.BasicConsume(queue: queueName,
        //                             autoAck: true,
        //                             consumer: consumer);
    }

    private void Consumer_Received(object? sender, BasicDeliverEventArgs e)
    {
        logger.LogInformation($"Processing Order at: {DateTime.UtcNow}");
    }
}


record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}


