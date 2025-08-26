using DarkoDemo.Messaging;
using DarkoDemo.Messaging.Extensions;
using MassTransit;
using Microsoft.Extensions.Caching.Memory;

namespace DarkoDemo.BasketApi.Messaging;

public class ProductDeletedConsumer(IMemoryCache cache, ILogger<ProductDeletedConsumer> logger) : IConsumer<ProductDeleted>
{
    private readonly IMemoryCache _cache = cache;
    private readonly ILogger<ProductDeletedConsumer> _logger = logger;

    public Task Consume(ConsumeContext<ProductDeleted> context)
    {
        var productId = context.Message.ProductId;

        foreach (var key in _cache.GetKeys().OfType<string>())
        {
            if (key.StartsWith("Basket:"))
            {
                _cache.Remove(key);
            }
        }

        _logger.LogInformation("Invalidated cache for Product {productId}", productId);

        return Task.CompletedTask;
    }
}
