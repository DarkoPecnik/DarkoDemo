using DarkoDemo.Shared.Services;
using DarkoDemo.Shared.Services.Interfaces;
using DarkoDemo.Web.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the DarkoDemo.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

builder.Services.AddHttpClient<CoreApiClient>(client => { client.BaseAddress = new("https://localhost:7212/"); });
builder.Services.AddHttpClient<CatalogApiClient>(client => { client.BaseAddress = new("https://localhost:7011/"); });

await builder.Build().RunAsync();
