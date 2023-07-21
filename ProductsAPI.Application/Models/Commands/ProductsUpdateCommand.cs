using System.ComponentModel.DataAnnotations;
using MediatR;
using ProductsAPI.Application.Models.Queries;

namespace ProductsAPI.Application.Models.Commands;

public class ProductsUpdateCommand : IRequest<ProductsDTO>
{
    [Required(ErrorMessage = "Provide the product's id")]
    public Guid? Id { get; set; }
    
    [Required(ErrorMessage = "Provide product's name")]
    [MinLength(8, ErrorMessage = "Provide at leats {1} characters")]
    [MaxLength(150, ErrorMessage = "Provide at most {1} characters")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Provide the product's price")]
    public decimal? Price { get; set; }

    [Required(ErrorMessage = "Provide the product's quantity")]
    public int? Quantity { get; set; }
    
    [Required(ErrorMessage = "Provide the product's creation date")]
    public DateTime? CreatedAt { get; set; }
}