using DarkoDemo.Services;
using DarkoDemo.Shared.Services;
using DarkoDemo.Shared.Services.Interfaces;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;

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

            builder.Services.AddSharedServices();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif
            builder.Services.AddMudServices();

            return builder.Build();
        }
    }
}
