using DarkoDemo.Shared.Services;
using DarkoDemo.Shared.Services.Interfaces;
using DarkoDemo.Web.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the DarkoDemo.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

builder.Services.AddSharedServices();

await builder.Build().RunAsync();
