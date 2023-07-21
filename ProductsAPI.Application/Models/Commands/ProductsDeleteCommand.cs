using MediatR;
using ProductsAPI.Application.Models.Queries;

namespace ProductsAPI.Application.Models.Commands;

public class ProductsDeleteCommand : IRequest<ProductsDTO>
{
    public Guid? Id { get; set; }
}