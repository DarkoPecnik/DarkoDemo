using DarkoDemo.DataServices.Base.Interfaces;

namespace DarkoDemo.Api.Extensions;

public static class DbMigrationExtension
{
    public static WebApplication MigrateDatabase(this WebApplication webApp)
    {
        using var scope = webApp.Services.CreateScope();
        var dbService = scope.ServiceProvider.GetRequiredService<IDatabaseService>();

        dbService.MigrateDatabase();

        return webApp;
    }
}