var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.DarkoDemo_Api>("darkodemo-api")
    .WithUrlForEndpoint("https", url => url.Url = "/scalar")
    .WithUrlForEndpoint("http", url => url.Url = "/scalar");

var catalogApiService = builder.AddProject<Projects.DarkoDemo_CatalogApi>("darkodemo-catalogapi")
    .WithUrlForEndpoint("https", url => url.Url = "/scalar")
    .WithUrlForEndpoint("http", url => url.Url = "/scalar");

var basketApiService = builder.AddProject<Projects.DarkoDemo_BasketApi>("darkodemo-basketapi")
    .WithUrlForEndpoint("https", url => url.Url = "/scalar")
    .WithUrlForEndpoint("http", url => url.Url = "/scalar");

builder.AddProject<Projects.DarkoDemo_Web>("darkodemo-web")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService)
    .WaitFor(catalogApiService)
    .WaitFor(basketApiService);

builder.Build().Run();
