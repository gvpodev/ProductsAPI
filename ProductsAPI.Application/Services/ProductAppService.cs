using MediatR;
using ProductsAPI.Application.Contracts;
using ProductsAPI.Application.Contracts.Services;
using ProductsAPI.Application.Contracts.Stores;
using ProductsAPI.Application.Models.Commands;
using ProductsAPI.Application.Models.Queries;

namespace ProductsAPI.Application.Services;

public class ProductAppService : IProductAppService
{
    private readonly IMediator? _mediator;
    private readonly IProductsStore? _productsStore;
    
    public ProductAppService(IMediator? mediator, IProductsStore? productsStore)
    {
        _mediator = mediator;
        _productsStore = productsStore;
    }

    public async Task<ProductsDTO> Create(ProductsCreateCommand command) => await _mediator?.Send(command);

    public async Task<ProductsDTO> Update(ProductsUpdateCommand command) => await _mediator?.Send(command);

    public async Task<ProductsDTO> Delete(ProductsDeleteCommand command) => await _mediator?.Send(command);
    public List<ProductsDTO> FindAll() => _productsStore?.FindAll();

    public ProductsDTO FindById(Guid id) => _productsStore?.FindById(id);
}