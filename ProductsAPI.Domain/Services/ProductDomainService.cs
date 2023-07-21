using ProductsAPI.Domain.Contracts.Repositories;
using ProductsAPI.Domain.Contracts.Services;
using ProductsAPI.Domain.Entities;

namespace ProductsAPI.Domain.Services;

public class ProductDomainService : BaseDomainService<Product, Guid>, IProductDomainService
{
    private readonly IUnitOfWork? _unitOfWork;

    public ProductDomainService(IUnitOfWork? unitOfWork) 
        : base(unitOfWork?.ProductRepository)
    {
        _unitOfWork = unitOfWork;
    }
}