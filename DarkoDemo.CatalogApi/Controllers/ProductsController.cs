using DarkoDemo.Messaging;
using DarkoDemo.Models;
using DarkoDemo.Services.Enums;
using DarkoDemo.Services.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace DarkoDemo.CatalogApi.Controllers;

[Route("[controller]")]
[ApiController]
public class ProductsController(IProductService productService, IMemoryCache cache, IPublishEndpoint publishEndpoint) : ControllerBase
{
    private readonly IProductService _productService = productService;
    private readonly IMemoryCache _cache = cache;
    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

    private const string ProductsCacheKey = "ProductsCache";

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        if (!_cache.TryGetValue(ProductsCacheKey, out List<ProductRead>? products))
        {
            products = await _productService.ReadProducts();
            _cache.Set(ProductsCacheKey, products, TimeSpan.FromMinutes(5));
        }

        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(ProductWrite product)
    {
        await _productService.CreateProduct(product);
        _cache.Remove(ProductsCacheKey);

        return CreatedAtAction(nameof(GetProducts), product);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        switch (await _productService.DeleteProduct(id))
        {
            case DeleteResult.Success:
                _cache.Remove(ProductsCacheKey);
                await _publishEndpoint.Publish(new ProductDeleted { ProductId = id });
                return NoContent();
            default:
                return NotFound();
        }
    }
}
