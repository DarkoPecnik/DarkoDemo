using DarkoDemo.DataServices.Base.Interfaces;

namespace DarkoDemo.DataServices.Base;

public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
{
    protected readonly AppDbContext _appDbContext = appDbContext;

    public async Task<int> SaveChanges()
    {
        return await _appDbContext.SaveChangesAsync();
    }
}
