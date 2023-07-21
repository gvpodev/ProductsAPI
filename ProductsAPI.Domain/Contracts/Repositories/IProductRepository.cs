using ProductsAPI.Domain.Entities;

namespace ProductsAPI.Domain.Contracts.Repositories;

public interface IProductRepository : IBaseRepository<Product, Guid>
{
    
}