using WorkerService1;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.AddRabbitMQ("messaging");

builder.AddServiceDefaults();
builder.Services.AddHostedService<Worker>();

builder.Services.AddHttpClient<WeatherStatisticsClient>(client => client.BaseAddress = new("http://weatherstatisticsservice2"));

IHost host = builder.Build();
host.Run();
