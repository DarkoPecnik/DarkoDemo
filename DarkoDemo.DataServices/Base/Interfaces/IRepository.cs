using DarkoDemo.Data.Base;
using System.Linq.Expressions;

namespace DarkoDemo.DataServices.Base.Interfaces;

public interface IRepository<TEntity> where TEntity : class, IBaseEntity
{
    Task<bool> Any();

    Task<int> Count();

    void Create(TEntity entity);

    void CreateRange(IEnumerable<TEntity> entities);

    void Delete(TEntity entity);

    void Modify(TEntity entity);

    Task<TEntity?> Edit<TSource>(Guid id, TSource entityDto);

    Task<bool> Exists(Guid? id);

    Task<bool> Exists<T>(Expression<Func<T, bool>> predicate) where T : class;

    Task<HashSet<Guid>> GetExistingIds(IEnumerable<Guid> ids);

    Task<TEntity?> Get(Expression<Func<TEntity, bool>> predicate);

    Task<TEntity?> GetFirst();

    Task<List<TEntity>> GetAll();

    Task<TEntity?> GetOne(Guid? id);

    Task<List<TEntity>> GetSome(int skip = 0, int take = 50);

    Task<List<TEntity>> GetSomeAfter(DateTimeOffset? lastCreatedAt = null, int take = 50);

    Task<List<TEntity>> ReadAll();

    Task<TEntity?> ReadFirst();

    Task<TEntity?> ReadOne(Guid id);

    Task<List<TEntity>> ReadSome(int skip = 0, int take = 50);

    Task<List<TEntity>> ReadSomeAfter(DateTimeOffset? lastCreatedAt = null, int take = 50);

    IQueryable<TEntity> Query();
}