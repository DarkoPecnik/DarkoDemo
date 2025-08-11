using DarkoDemo.DataServices.Base.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DarkoDemo.DataServices.Base;

internal class DatabaseService(AppDbContext appDbContext) : IDatabaseService
{
    protected readonly AppDbContext _appDbContext = appDbContext;

    public void MigrateDatabase()
    {
        _appDbContext.Database.Migrate();
    }
}