using ProductsAPI.Domain.Contracts.Repositories;
using ProductsAPI.Infra.Data.SqlServer.Contexts;

namespace ProductsAPI.Infra.Data.SqlServer.Repositories;

public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
    where TEntity : class
{
    private readonly DataContext? _context;

    protected BaseRepository(DataContext? context)
    {
        _context = context;
    }

    public virtual void Add(TEntity entity) => _context?.Set<TEntity>().Add(entity);

    public virtual void Update(TEntity entity) => _context?.Set<TEntity>().Update(entity);

    public virtual void Delete(TEntity entity) => _context?.Set<TEntity>().Remove(entity);

    public virtual List<TEntity> FindAll() => _context?.Set<TEntity>().ToList();

    public virtual TEntity Find(TKey id) => _context?.Set<TEntity>().Find(id);
    public void SaveChanges() => _context?.SaveChanges();

    public virtual void Dispose() => _context?.Dispose();
}