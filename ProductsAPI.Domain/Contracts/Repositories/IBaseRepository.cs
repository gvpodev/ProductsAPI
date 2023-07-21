namespace ProductsAPI.Domain.Contracts.Repositories;

public interface IBaseRepository<TEntity, TKey> : IDisposable
    where TEntity : class
{
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    List<TEntity> FindAll();
    TEntity Find(TKey id);
    void SaveChanges();
}