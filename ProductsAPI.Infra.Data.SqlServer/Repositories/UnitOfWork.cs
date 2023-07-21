using ProductsAPI.Domain.Contracts.Repositories;
using ProductsAPI.Infra.Data.SqlServer.Contexts;

namespace ProductsAPI.Infra.Data.SqlServer.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext? _context;

    public UnitOfWork(DataContext? context)
    {
        _context = context;
    }

    public IProductRepository ProductRepository => new ProductRepository(_context);
    
    public void SaveChanges()
    {
        _context?.SaveChanges();
    }
    
    public void Dispose()
    {
        _context?.Dispose();
    }
}