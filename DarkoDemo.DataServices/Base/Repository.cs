using DarkoDemo.Data.Base;
using DarkoDemo.DataServices.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DarkoDemo.DataServices.Base;

public class Repository<TEntity>(AppDbContext appDbContext) : IRepository<TEntity> where TEntity : class, IBaseEntity
{
    protected readonly AppDbContext _appDbContext = appDbContext;

    public async Task<bool> Any()
    {
        return await _appDbContext.Set<TEntity>().AnyAsync();
    }

    public async Task<int> Count()
    {
        return await _appDbContext.Set<TEntity>().CountAsync();
    }

    public void Create(TEntity entity)
    {
        _appDbContext.Add(entity);
    }

    public void CreateRange(IEnumerable<TEntity> entities)
    {
        _appDbContext.AddRange(entities);
    }

    public void Delete(TEntity entity)
    {
        _appDbContext.Remove(entity);
    }

    public void Modify(TEntity entity)
    {
        _appDbContext.Entry(entity).State = EntityState.Modified;
    }

    public async Task<TEntity?> Edit<TEntityDto>(Guid id, TEntityDto entityDto)
    {
        var tracked = await _appDbContext.Set<TEntity>().FindAsync(id);

        if (tracked is not null && entityDto is not null)
        {
            _appDbContext.Entry(tracked).CurrentValues.SetValues(entityDto);
        }

        return tracked;
    }

    public async Task<bool> Exists(Guid? id)
    {
        return await _appDbContext.Set<TEntity>().AnyAsync(x => x.Id == id);
    }

    public async Task<bool> Exists<T>(Expression<Func<T, bool>> predicate) where T : class
    {
        return await _appDbContext.Set<T>().AnyAsync(predicate);
    }

    public async Task<HashSet<Guid>> GetExistingIds(IEnumerable<Guid> ids)
    {
        return await _appDbContext.Set<TEntity>().Where(e => ids.Contains(e.Id)).Select(e => e.Id).ToHashSetAsync();
    }

    public async Task<TEntity?> Get(Expression<Func<TEntity, bool>> predicate)
    {
        return await _appDbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
    }

    public async Task<TEntity?> GetFirst()
    {
        return await _appDbContext.Set<TEntity>().FirstOrDefaultAsync();
    }

    public async Task<List<TEntity>> GetAll()
    {
        return await _appDbContext.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetOne(Guid? id)
    {
        return await _appDbContext.Set<TEntity>().FindAsync(id);
    }

    public async Task<List<TEntity>> GetSome(int skip = 0, int take = 50)
    {
        return await _appDbContext.Set<TEntity>().Skip(skip).Take(take).ToListAsync();
    }

    public async Task<List<TEntity>> GetSomeAfter(DateTimeOffset? lastCreatedAt = null, int take = 50)
    {
        var query = _appDbContext.Set<TEntity>().OrderBy(e => e.CreatedDate).AsQueryable();

        if (lastCreatedAt.HasValue)
        {
            query = query.Where(e => e.CreatedDate > lastCreatedAt.Value);
        }

        return await query.Take(take).ToListAsync();
    }

    public async Task<TEntity?> ReadFirst()
    {
        return await _appDbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync();
    }

    public async Task<List<TEntity>> ReadAll()
    {
        return await _appDbContext.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    public async Task<TEntity?> ReadOne(Guid id)
    {
        return await _appDbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<List<TEntity>> ReadSome(int skip = 0, int take = 50)
    {
        return await _appDbContext.Set<TEntity>().AsNoTracking().Skip(skip).Take(take).ToListAsync();
    }

    public async Task<List<TEntity>> ReadSomeAfter(DateTimeOffset? lastCreatedAt = null, int take = 50)
    {
        var query = _appDbContext.Set<TEntity>().OrderBy(e => e.CreatedDate).AsQueryable().AsNoTracking();

        if (lastCreatedAt.HasValue)
        {
            query = query.Where(e => e.CreatedDate > lastCreatedAt.Value);
        }

        return await query.Take(take).ToListAsync();
    }
}
