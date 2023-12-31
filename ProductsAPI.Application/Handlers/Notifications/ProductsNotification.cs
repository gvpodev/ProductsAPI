using MediatR;
using ProductsAPI.Application.Models.Queries;

namespace ProductsAPI.Application.Handlers.Notifications;

public class ProductsNotification : INotification
{
    public ActionNotification? Action { get; set; }
    public ProductsDTO? ProductsDto { get; set; }
}

public enum ActionNotification
{
    Created,
    Updated,
    Deleted
}