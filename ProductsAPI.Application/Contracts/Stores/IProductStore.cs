using ProductsAPI.Application.Models.Queries;

namespace ProductsAPI.Application.Contracts.Stores;

public interface IProductStore
{
    void Add(ProductsQuery item);
    void Update(ProductsQuery item);
    void Delete(Guid id);
    List<ProductsQuery> FindAll();
    ProductsQuery FindById(Guid id);
}