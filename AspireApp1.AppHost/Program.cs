IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

IResourceBuilder<RedisContainerResource> cache = builder.AddRedisContainer("cache");

IResourceBuilder<ProjectResource> weatherStatisticsService = builder.AddProject<Projects.Aspire1_WeatherStatisticsService>("weatherstatisticsservice2");

IResourceBuilder<ProjectResource> apiservice = builder.AddProject<Projects.AspireApp1_ApiService>("apiservice");
//.WithReference(weatherStatisticsService);

builder.AddProject<Projects.AspireApp1_Web>("webfrontend")
    .WithReference(cache)
    .WithReference(weatherStatisticsService)
.WithReference(apiservice);

builder.Build().Run();
