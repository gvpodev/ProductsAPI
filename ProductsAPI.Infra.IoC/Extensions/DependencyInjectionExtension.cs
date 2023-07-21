using Microsoft.Extensions.DependencyInjection;
using ProductsAPI.Application.Contracts.Services;
using ProductsAPI.Application.Contracts.Stores;
using ProductsAPI.Application.Services;
using ProductsAPI.Domain.Contracts.Repositories;
using ProductsAPI.Domain.Contracts.Services;
using ProductsAPI.Domain.Services;
using ProductsAPI.Infra.Data.MongoDB.Stores;
using ProductsAPI.Infra.Data.SqlServer.Repositories;

namespace ProductsAPI.Infra.IoC.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        services.AddTransient<IProductAppService, ProductAppService>();
        services.AddTransient<IProductDomainService, ProductDomainService>();
        services.AddTransient<IProductsStore, ProductsStore>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        
        return services;
    }
}