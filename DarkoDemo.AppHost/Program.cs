var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.DarkoDemo_Api>("darkodemo-api")
    .WithUrlForEndpoint("https", url => url.Url = "/scalar")
    .WithUrlForEndpoint("http", url => url.Url = "/scalar");

builder.AddProject<Projects.DarkoDemo_Web>("darkodemo-web")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);


builder.Build().Run();
