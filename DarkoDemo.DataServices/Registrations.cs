using DarkoDemo.DataServices.Base;
using DarkoDemo.DataServices.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DarkoDemo.DataServices;

public static class Registrations
{
    public static IServiceCollection AddDataServices(this IServiceCollection services, string sqlConnectionString)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(sqlConnectionString));

        // Generic repositories
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IDatabaseService, DatabaseService>();

        return services;
    }
}
