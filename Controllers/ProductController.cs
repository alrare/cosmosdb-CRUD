using CosmosDbCRUD.Models;
using Microservice.Read.Services;
using Microsoft.AspNetCore.Mvc;

namespace CosmosDbCRUD.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    public readonly IProductCosmosService _productCosmosService;
    public ProductController(IProductCosmosService productCosmosService)
    {
        _productCosmosService = productCosmosService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var sqlCosmosQuery = "Select * from c";
        var result = await _productCosmosService.Get(sqlCosmosQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Product newProduct)
    {
        newProduct.Id = Guid.NewGuid().ToString();
        var result = await _productCosmosService.AddAsync(newProduct);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(Product productToUpdate)
    {
        var result = await _productCosmosService.Update(productToUpdate);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        await _productCosmosService.Delete(id);
        return Ok();
    }

}