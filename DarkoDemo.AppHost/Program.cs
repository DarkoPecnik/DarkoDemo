var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.DarkoDemo_Web>("darkodemo-web");

builder.AddProject<Projects.DarkoDemo_Api>("darkodemo-api");

builder.Build().Run();
