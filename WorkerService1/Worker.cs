using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace WorkerService1;

public class Worker(ILogger<Worker> logger, IConnection rabbitMqConnection) : BackgroundService
{
    private readonly ILogger<Worker> _logger = logger;
    private const string queueName = "randomqueue";
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);


                IModel _messageChannel = rabbitMqConnection.CreateModel();
                _messageChannel.QueueDeclare(queueName, exclusive: false);

                EventingBasicConsumer consumer = new EventingBasicConsumer(_messageChannel);
                //consumer.Received += Consumer_Received;

                _messageChannel.BasicConsume(queue: queueName,
                                             autoAck: true,
                                             consumer: consumer);

            }
            await Task.Delay(1000, stoppingToken);
        }
    }
}
