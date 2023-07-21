using ProductsAPI.Domain.Entities;

namespace ProductsAPI.Domain.Contracts.Services;

public interface IProductDomainService : IBaseDomainService<Product, Guid>
{
    
}