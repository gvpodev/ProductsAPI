using ProductsAPI.Application.Models.Commands;
using ProductsAPI.Application.Models.Queries;

namespace ProductsAPI.Application.Contracts.Services;

public interface IProductAppService
{
    Task<ProductsDTO> Create(ProductsCreateCommand command);
    Task<ProductsDTO> Update(ProductsUpdateCommand command);
    Task<ProductsDTO> Delete(ProductsDeleteCommand command);

    List<ProductsDTO> FindAll();
    ProductsDTO FindById(Guid id);
}