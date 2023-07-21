namespace ProductsAPI.Infra.Data.MongoDB.Settings;

public class MongoDbSettings
{
    public string? Host { get; set; }
    public string? Name { get; set; }
    public bool IsSsl { get; set; }
}