using Microsoft.Extensions.DependencyInjection;

namespace DarkoDemo.Shared.Services;

public static class Registrations
{
    public static IServiceCollection AddSharedServices(this IServiceCollection services)
    {
        services.AddHttpClient<CoreApiClient>(client => { client.BaseAddress = new("https://localhost:7212/"); });
        services.AddHttpClient<CatalogApiClient>(client => { client.BaseAddress = new("https://localhost:7011/"); });
        services.AddHttpClient<BasketApiClient>(client => { client.BaseAddress = new("https://localhost:7273/"); });

        services.AddSingleton<CustomerSwitcherService>();

        return services;
    }
}
