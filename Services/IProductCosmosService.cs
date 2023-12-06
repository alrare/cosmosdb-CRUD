using CosmosDbCRUD.Models;

namespace Microservice.Read.Services;

public interface IProductCosmosService
{
    Task<List<Product>> Get(string sqlCosmosQuery);
    Task<Product> AddAsync(Product newProduct);
    Task<Product> Update(Product productToUpdate);

    Task Delete(string id);
}