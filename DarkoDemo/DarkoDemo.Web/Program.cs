using DarkoDemo.Shared.Services.Interfaces;
using DarkoDemo.Web.Components;
using DarkoDemo.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddOutputCache();

// Add device-specific services used by the DarkoDemo.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseOutputCache();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(
        typeof(DarkoDemo.Shared._Imports).Assembly,
        typeof(DarkoDemo.Web.Client._Imports).Assembly);

app.Run();
