using DarkoDemo.Data.Base;
using DarkoDemo.Services.Interfaces;

namespace DarkoDemo.Services;

public abstract class BaseEntityService : IBaseEntityService
{
    public void InitializeForCreate<TEntity>(TEntity entity) where TEntity : class, IBaseEntity
    {
        entity.Id = Guid.CreateVersion7();
        entity.CreatedDate = DateTime.UtcNow;
        entity.Active = true;
    }
}
