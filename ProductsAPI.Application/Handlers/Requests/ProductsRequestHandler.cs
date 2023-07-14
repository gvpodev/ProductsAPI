using MediatR;
using ProductsAPI.Application.Models.Commands;
using ProductsAPI.Application.Models.Queries;

namespace ProductsAPI.Application.Handlers.Requests;

public class ProductsRequestHandler : 
    IRequestHandler<ProductsCreateCommand, ProductsQuery>,
    IRequestHandler<ProductsUpdateCommand, ProductsQuery>,
    IRequestHandler<ProductsDeleteCommand, ProductsQuery>
{
    public Task<ProductsQuery> Handle(ProductsCreateCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ProductsQuery> Handle(ProductsUpdateCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ProductsQuery> Handle(ProductsDeleteCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}