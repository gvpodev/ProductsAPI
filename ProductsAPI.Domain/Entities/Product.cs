﻿namespace ProductsAPI.Domain.Entities;

public class Product
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public int? Quantity { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}