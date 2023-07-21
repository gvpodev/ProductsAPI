namespace ProductsAPI.Domain.Contracts.Repositories;

public interface IUnitOfWork : IDisposable
{
    public IProductRepository ProductRepository { get; }
    void SaveChanges();
}