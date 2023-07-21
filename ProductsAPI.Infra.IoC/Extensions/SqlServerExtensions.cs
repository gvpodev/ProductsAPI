using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductsAPI.Infra.Data.SqlServer.Contexts;

namespace ProductsAPI.Infra.IoC.Extensions;

public static class SqlServerExtensions
{
    public static IServiceCollection AddSqlServerConfig(
        this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ProductsAPI");

        services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
        
        return services;
    }
}