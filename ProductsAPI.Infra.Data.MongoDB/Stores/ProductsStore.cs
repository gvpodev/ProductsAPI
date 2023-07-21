using MongoDB.Driver;
using ProductsAPI.Application.Contracts.Stores;
using ProductsAPI.Application.Models.Queries;
using ProductsAPI.Infra.Data.MongoDB.Contexts;

namespace ProductsAPI.Infra.Data.MongoDB.Stores;

public class ProductsStore : IProductsStore
{
    private readonly MongoDbContext? _context;

    public ProductsStore(MongoDbContext? context)
    {
        _context = context;
    }

    public void Add(ProductsDTO item) => _context?.Products?.InsertOne(item);

    public void Update(ProductsDTO item)
    {
        var filter = Builders<ProductsDTO>.Filter.Eq(p => p.Id, item.Id);
        _context?.Products?.ReplaceOne(filter, item);
    }

    public void Delete(Guid id)
    {
        var filter = Builders<ProductsDTO>.Filter.Eq(p => p.Id, id);
        _context?.Products?.DeleteOne(filter);
    }

    public List<ProductsDTO> FindAll()
    {
        var filter = Builders<ProductsDTO>.Filter.Where(p => true);
        return _context?.Products?.Find(filter).ToList();
    }

    public ProductsDTO FindById(Guid id)
    {
        var filter = Builders<ProductsDTO>.Filter.Eq(p => p.Id, id);
        return _context?.Products?.Find(filter).FirstOrDefault();
    }
}