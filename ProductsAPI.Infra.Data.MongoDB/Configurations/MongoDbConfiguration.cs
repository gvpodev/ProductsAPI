namespace ProductsAPI.Infra.Data.MongoDB.Configurations;

public class MongoDbConfiguration
{
    public string? Host { get; set; }
    public string? Name { get; set; }
    public bool IsSsl { get; set; }
}