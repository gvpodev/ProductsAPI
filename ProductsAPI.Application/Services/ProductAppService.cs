using MediatR;
using ProductsAPI.Application.Contracts;
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

    public async Task<ProductsQuery> Create(ProductsCreateCommand command)
    {
        return await _mediator?.Send(command);
    }

    public async Task<ProductsQuery> Update(ProductsUpdateCommand command)
    {
        return await _mediator?.Send(command);
    }

    public async Task<ProductsQuery> Delete(ProductsDeleteCommand command)
    {
        return await _mediator?.Send(command);
    }
}