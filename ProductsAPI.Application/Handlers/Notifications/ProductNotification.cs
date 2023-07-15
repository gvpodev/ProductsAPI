using ProductsAPI.Application.Models.Queries;

namespace ProductsAPI.Application.Handlers.Notifications;

public class ProductNotification
{
    public ActionNotification? Action { get; set; }
    public ProductsQuery? ProductsQuery { get; set; }
}

public enum ActionNotification
{
    Created,
    Updated,
    Deleted
}