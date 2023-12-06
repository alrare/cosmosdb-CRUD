using CosmosDbCRUD.Models;
using Microsoft.Azure.Cosmos;

namespace Microservice.Read.Services;

public class ProductCosmosService : IProductCosmosService
{
    private readonly Container _container;
    public ProductCosmosService(CosmosClient cosmosClient,
    string databaseName,
    string containerName)
    {
        _container = cosmosClient.GetContainer(databaseName, containerName);
    }

    public async Task<List<Product>> Get(string sqlCosmosQuery)
    {
        var query = _container.GetItemQueryIterator<Product>(new QueryDefinition(sqlCosmosQuery));

        List<Product> result = new List<Product>();
        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            result.AddRange(response);
        }

        return result;
    }

    public async Task<Product> AddAsync(Product newProduct)
    {
        var item = await _container.CreateItemAsync<Product>(newProduct, new PartitionKey(newProduct.Id));
        return item;
    }

    public async Task<Product> Update(Product ProductsToUpdate)
    {
        var item = await _container.UpsertItemAsync<Product>(ProductsToUpdate, new PartitionKey(ProductsToUpdate.Id));
        return item;
    }

    public async Task Delete(string id)
    {
        await _container.DeleteItemAsync<Product>(id, new PartitionKey(id));
    }
}