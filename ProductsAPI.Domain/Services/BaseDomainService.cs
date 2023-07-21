using ProductsAPI.Domain.Contracts.Repositories;
using ProductsAPI.Domain.Contracts.Services;

namespace ProductsAPI.Domain.Services;

public abstract class BaseDomainService<TEntity, TKey> : IBaseDomainService<TEntity, TKey>
    where TEntity : class
{
    private readonly IBaseRepository<TEntity, TKey>? _repository;

    protected BaseDomainService(IBaseRepository<TEntity, TKey>? repository)
    {
        _repository = repository;
    }

    public virtual void Add(TEntity entity)
    {
        _repository?.Add(entity);
        _repository?.SaveChanges();
    }

    public virtual void Update(TEntity entity)
    {
        _repository?.Update(entity);
        _repository?.SaveChanges();
    }

    public virtual void Delete(TEntity entity)
    {
        _repository?.Delete(entity);
        _repository?.SaveChanges();
    }

    public virtual List<TEntity> GetAll() => _repository?.FindAll();

    public virtual TEntity GetById(TKey id) => _repository?.Find(id);

    public virtual void Dispose() => _repository?.Dispose();
}