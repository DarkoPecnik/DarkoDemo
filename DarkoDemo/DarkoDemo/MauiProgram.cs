using DarkoDemo.Services;
using DarkoDemo.Shared.Services;
using DarkoDemo.Shared.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace DarkoDemo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // Add device-specific services used by the DarkoDemo.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();

            builder.Services.AddHttpClient<CoreApiClient>(client => { client.BaseAddress = new("https://localhost:7212/"); });
            builder.Services.AddHttpClient<CatalogApiClient>(client => { client.BaseAddress = new("https://localhost:7011/"); });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
