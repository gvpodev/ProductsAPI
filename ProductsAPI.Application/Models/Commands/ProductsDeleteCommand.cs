using MediatR;
using ProductsAPI.Application.Models.Queries;

namespace ProductsAPI.Application.Models.Commands;

public class ProductsDeleteCommand : IRequest<ProductsQuery>
{
    public Guid? Id { get; set; }
}