using DarkoDemo.Models;
using DarkoDemo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace DarkoDemo.BasketApi.Controllers;

[Route("[controller]")]
[ApiController]
public class BasketController(IBasketService basketService, IMemoryCache cache) : ControllerBase
{
    private readonly IBasketService _basketService = basketService;
    private readonly IMemoryCache _cache = cache;

    private const string BasketCacheKeyPrefix = "Basket:";

    [HttpGet("{customerId}")]
    public async Task<IActionResult> GetBasket(Guid customerId)
    {
        if (customerId == Guid.Empty) return BadRequest("CustomerId is required.");

        string cacheKey = $"{BasketCacheKeyPrefix}{customerId}";

        if (_cache.TryGetValue(cacheKey, out BasketRead? basket))
        {
            return Ok(basket);
        }

        basket = await _basketService.ReadBasket(customerId);

        if (basket is null)
        {
            return NotFound("Basket not found.");
        }

        _cache.Set(cacheKey, basket, TimeSpan.FromMinutes(5));

        return Ok(basket);
    }

    [HttpPost("{productId}")]
    public async Task<IActionResult> AddToBasket(Guid productId, [FromQuery] Guid customerId)
    {
        if (customerId == Guid.Empty) return BadRequest("CustomerId is required.");

        string cacheKey = $"{BasketCacheKeyPrefix}{customerId}";

        var basket = await _basketService.GetBasket(customerId);

        var item = basket.Items.FirstOrDefault(i => i.ProductId == productId);

        if (item is not null)
        {
            await _basketService.IncrementBasketItem(item.Id);
        }
        else
        {
            await _basketService.CreateBasketItem(basket.Id, productId);

        }

        _cache.Remove(cacheKey);

        return Ok();
    }
}
