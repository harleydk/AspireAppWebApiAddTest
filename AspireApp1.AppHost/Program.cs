
IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

IResourceBuilder<RedisContainerResource> cache = builder.AddRedisContainer("cache");


IResourceBuilder<RabbitMQContainerResource> messaging = builder.AddRabbitMQContainer("messaging");
//Microsoft.Extensions.Hosting.AspireRabbitMQExtensions.AddRabbitMQ("messaging");  //builder.AddRabbitMQContainer("messaging");

IResourceBuilder<ProjectResource> weatherStatisticsService = builder.AddProject<Projects.Aspire1_WeatherStatisticsService>("weatherstatisticsservice2");

IResourceBuilder<ProjectResource> apiservice = builder.AddProject<Projects.AspireApp1_ApiService>("apiservice");
//.WithReference(weatherStatisticsService);

_ = builder.AddProject<Projects.WorkerService1>("workerService")
    .WithReference(weatherStatisticsService)
    .WithReference(messaging);

builder.AddProject<Projects.AspireApp1_Web>("webfrontend")
    .WithReference(cache)
    .WithReference(weatherStatisticsService)
    .WithReference(apiservice);

builder.Build().Run();
