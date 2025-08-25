using DarkoDemo.Data;
using DarkoDemo.Models;

namespace DarkoDemo.Services.Interfaces;

public interface IBasketService
{
    Task<BasketRead?> ReadBasket(Guid customerId);

    Task<Basket> GetBasket(Guid customerId);

    Task<int> CreateBasketItem(Guid basketId, Guid productId);

    Task<int> IncrementBasketItem(Guid basketItemId);
}
