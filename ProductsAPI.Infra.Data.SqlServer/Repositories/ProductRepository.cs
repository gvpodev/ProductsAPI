using ProductsAPI.Domain.Contracts.Repositories;
using ProductsAPI.Domain.Entities;
using ProductsAPI.Infra.Data.SqlServer.Contexts;

namespace ProductsAPI.Infra.Data.SqlServer.Repositories;

public class ProductRepository : BaseRepository<Product, Guid>, IProductRepository
{
    private readonly DataContext? _context;

    public ProductRepository(DataContext? context) : base(context)
    {
        _context = context;
    }
}