namespace ProductsAPI.Application.Models.Queries;

public class ProductsDTO
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public int? Quantity { get; set; }
    public decimal? Total => Price * Quantity;
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}