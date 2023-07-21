using System.Diagnostics;
using MediatR;
using ProductsAPI.Application.Handlers.Notifications;
using ProductsAPI.Application.Models.Commands;
using ProductsAPI.Application.Models.Queries;

namespace ProductsAPI.Application.Handlers.Requests;

public class ProductsRequestHandler : 
    IRequestHandler<ProductsCreateCommand, ProductsQuery>,
    IRequestHandler<ProductsUpdateCommand, ProductsQuery>,
    IRequestHandler<ProductsDeleteCommand, ProductsQuery>
{
    private readonly IMediator? _mediator;

    public ProductsRequestHandler(IMediator? mediator)
    {
        _mediator = mediator;
    }

    public async Task<ProductsQuery> Handle(ProductsCreateCommand request, CancellationToken cancellationToken)
    {
        Debug.WriteLine("Cadastrando produto no domínio");

        var query = new ProductsQuery
        {
            Id = new Guid(),
            Name = request.Name,
            Price = request.Price,
            Quantity = request.Quantity,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        
        await _mediator?.Publish(new ProductsNotification
        {
            Action = ActionNotification.Created,
            ProductsQuery = query
        })!;

        return query;
    }

    public async Task<ProductsQuery> Handle(ProductsUpdateCommand request, CancellationToken cancellationToken)
    {
        Debug.WriteLine("Atualizando produto no domínio");

        var query = new ProductsQuery
        {
            Id = new Guid(),
            Name = request.Name,
            Price = request.Price,
            Quantity = request.Quantity,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        
        await _mediator?.Publish(new ProductsNotification
        {
            Action = ActionNotification.Updated,
            ProductsQuery = query
        })!;

        return query;
    }

    public async Task<ProductsQuery> Handle(ProductsDeleteCommand request, CancellationToken cancellationToken)
    {
        Debug.WriteLine("Deletando produto no domínio");

        var query = new ProductsQuery
        {
            Id = request.Id
        };
        
        await _mediator?.Publish(new ProductsNotification
        {
            Action = ActionNotification.Deleted,
            ProductsQuery = query
        })!;

        return query;
    }
}