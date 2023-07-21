using Microsoft.Extensions.Options;
using ProductsAPI.Infra.Data.MongoDB.Configurations;

namespace ProductsAPI.Infra.Data.MongoDB.Contexts;

public class MongDbContext
{
    private readonly MongoDbConfiguration? _configuration;

    public MongDbContext(IOptions<MongoDbConfiguration>? configuration)
    {
        _configuration = configuration?.Value;
    }
}