using System.Diagnostics;
using MediatR;
using ProductsAPI.Application.Handlers.Notifications;
using ProductsAPI.Application.Models.Commands;
using ProductsAPI.Application.Models.Queries;
using ProductsAPI.Domain.Contracts.Services;
using ProductsAPI.Domain.Entities;

namespace ProductsAPI.Application.Handlers.Requests;

public class ProductsRequestHandler : 
    IRequestHandler<ProductsCreateCommand, ProductsDTO>,
    IRequestHandler<ProductsUpdateCommand, ProductsDTO>,
    IRequestHandler<ProductsDeleteCommand, ProductsDTO>
{
    private readonly IMediator? _mediator;
    private readonly IProductDomainService? _productDomainService;

    public ProductsRequestHandler(IMediator? mediator, IProductDomainService productDomainService)
    {
        _mediator = mediator;
        _productDomainService = productDomainService;
    }

    public async Task<ProductsDTO> Handle(ProductsCreateCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Price = request.Price,
            Quantity = request.Quantity,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        
        _productDomainService?.Add(product);

        var dto = new ProductsDTO
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Quantity = product.Quantity,
            CreatedAt = product.CreatedAt,
            UpdatedAt = product.UpdatedAt
        };
        
        await _mediator?.Publish(new ProductsNotification
        {
            Action = ActionNotification.Created,
            ProductsDto = dto
        })!;

        return dto;
    }

    public async Task<ProductsDTO> Handle(ProductsUpdateCommand request, CancellationToken cancellationToken)
    {
        var product = _productDomainService?.GetById(request.Id.Value);

        var dto = new ProductsDTO
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Quantity = product.Quantity,
            CreatedAt = product.CreatedAt,
            UpdatedAt = product.UpdatedAt
        };
        
        await _mediator?.Publish(new ProductsNotification
        {
            Action = ActionNotification.Updated,
            ProductsDto = dto
        })!;

        return dto;
    }

    public async Task<ProductsDTO> Handle(ProductsDeleteCommand request, CancellationToken cancellationToken)
    {
        var product = _productDomainService?.GetById(request.Id.Value);

        var dto = new ProductsDTO
        {
            Id = product.Id
        };
        
        await _mediator?.Publish(new ProductsNotification
        {
            Action = ActionNotification.Deleted,
            ProductsDto = dto
        })!;

        return dto;
    }
}