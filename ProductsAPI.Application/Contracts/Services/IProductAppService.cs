using ProductsAPI.Application.Models.Commands;
using ProductsAPI.Application.Models.Queries;

namespace ProductsAPI.Application.Contracts.Services;

public interface IProductAppService
{
    Task<ProductsQuery> Create(ProductsCreateCommand command);
    Task<ProductsQuery> Update(ProductsUpdateCommand command);
    Task<ProductsQuery> Delete(ProductsDeleteCommand command);
}