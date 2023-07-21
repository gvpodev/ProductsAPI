using System.Security.Authentication;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductsAPI.Application.Models.Queries;
using ProductsAPI.Infra.Data.MongoDB.Settings;

namespace ProductsAPI.Infra.Data.MongoDB.Contexts;

public class MongoDbContext
{
    private readonly MongoDbSettings? _configuration;
    private IMongoDatabase? _mongoDatabase;

    public MongoDbContext(IOptions<MongoDbSettings>? configuration)
    {
        _configuration = configuration?.Value;

        var client = MongoClientSettings.FromUrl(new MongoUrl(_configuration?.Host));
        
        if (_configuration is { IsSsl: true })
        {
            client.SslSettings = new SslSettings
            {
                EnabledSslProtocols = SslProtocols.Tls12
            };
        }
        
        _mongoDatabase = new MongoClient(client).GetDatabase(_configuration?.Name);
    }

    public IMongoCollection<ProductsDTO>? Products => _mongoDatabase?.GetCollection<ProductsDTO>(name: "Products");
}