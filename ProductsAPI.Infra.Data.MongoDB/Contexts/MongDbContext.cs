﻿using System.Security.Authentication;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductsAPI.Application.Models.Queries;
using ProductsAPI.Infra.Data.MongoDB.Configurations;

namespace ProductsAPI.Infra.Data.MongoDB.Contexts;

public class MongDbContext
{
    private readonly MongoDbConfiguration? _configuration;
    private IMongoDatabase? _mongoDatabase;

    public MongDbContext(IOptions<MongoDbConfiguration>? configuration)
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