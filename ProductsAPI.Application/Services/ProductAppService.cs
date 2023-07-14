using ProductsAPI.Application.Contracts;
using ProductsAPI.Application.Models.Commands;
using ProductsAPI.Application.Models.Queries;

namespace ProductsAPI.Application.Services;

public class ProductAppService : IProductAppService
{
    public Task<ProductsQuery> Create(ProductsCreateCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<ProductsQuery> Update(ProductsUpdateCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<ProductsQuery> Delete(ProductsDeleteCommand command)
    {
        throw new NotImplementedException();
    }
}