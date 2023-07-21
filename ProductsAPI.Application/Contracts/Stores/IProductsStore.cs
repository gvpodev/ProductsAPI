using ProductsAPI.Application.Models.Queries;

namespace ProductsAPI.Application.Contracts.Stores;

public interface IProductsStore
{
    void Add(ProductsDTO item);
    void Update(ProductsDTO item);
    void Delete(Guid id);
    List<ProductsDTO> FindAll();
    ProductsDTO FindById(Guid id);
}