using DarkoDemo.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DarkoDemo.Services;

public static class Registrations
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICustomerService, CustomerService>();

        return services;
    }
}
