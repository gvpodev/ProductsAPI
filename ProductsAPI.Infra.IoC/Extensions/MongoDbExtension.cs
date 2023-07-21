using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductsAPI.Infra.Data.MongoDB.Contexts;
using ProductsAPI.Infra.Data.MongoDB.Settings;

namespace ProductsAPI.Infra.IoC.Extensions;

public static class MongoDbExtension
{
    public static IServiceCollection AddMongoDbConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));
        services.AddTransient<MongoDbContext>();

        return services;
    }
}