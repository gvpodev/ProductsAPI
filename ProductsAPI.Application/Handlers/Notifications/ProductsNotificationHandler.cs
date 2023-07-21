using System.Diagnostics;
using MediatR;
using ProductsAPI.Application.Contracts.Stores;

namespace ProductsAPI.Application.Handlers.Notifications;

public class ProductsNotificationHandler : INotificationHandler<ProductsNotification>
{
    private readonly IProductsStore? _productsStore;

    public ProductsNotificationHandler(IProductsStore? productsStore)
    {
        _productsStore = productsStore;
    }

    public Task Handle(ProductsNotification notification, CancellationToken cancellationToken)
    {
        switch (notification.Action)
        {
            case ActionNotification.Created:
                _productsStore?.Add(notification.ProductsDto);
                break;
            case ActionNotification.Updated:
                _productsStore?.Update(notification.ProductsDto);
                break;
            case ActionNotification.Deleted:
                _productsStore?.Delete(notification.ProductsDto.Id.Value);
                break;
        }

        return Task.CompletedTask;
    }
}