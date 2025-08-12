using DarkoDemo.Data.Base;

namespace DarkoDemo.Services.Interfaces;

public interface IBaseEntityService
{
    void InitializeForCreate<TEntity>(TEntity entity) where TEntity : class, IBaseEntity;
}
