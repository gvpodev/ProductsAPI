using MediatR;
using ProductsAPI.Application.Contracts;
using ProductsAPI.Application.Contracts.Services;
using ProductsAPI.Application.Models.Commands;
using ProductsAPI.Application.Models.Queries;

namespace ProductsAPI.Application.Services;

public class ProductAppService : IProductAppService
{
    private readonly IMediator? _mediator;

    public ProductAppService(IMediator? mediator)
    {
        _mediator = mediator;
    }

    public async Task<ProductsDTO> Create(ProductsCreateCommand command)
    {
        return await _mediator?.Send(command);
    }

    public async Task<ProductsDTO> Update(ProductsUpdateCommand command)
    {
        return await _mediator?.Send(command);
    }

    public async Task<ProductsDTO> Delete(ProductsDeleteCommand command)
    {
        return await _mediator?.Send(command);
    }
}