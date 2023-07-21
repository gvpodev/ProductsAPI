using System.Diagnostics;
using MediatR;

namespace ProductsAPI.Application.Handlers.Notifications;

public class ProductsNotificationHandler : INotificationHandler<ProductsNotification>
{
    public Task Handle(ProductsNotification notification, CancellationToken cancellationToken)
    {
        Debug.WriteLine($"Recebendo notificação de: {notification.Action}");
        Debug.WriteLine("Produto gravado, alterado ou excluído no banco de cache");
        Debug.WriteLine($"{notification.ProductsDto?.Name}");
        
        return Task.CompletedTask;
    }
}