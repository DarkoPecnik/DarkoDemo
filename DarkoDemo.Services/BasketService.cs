using DarkoDemo.Data;
using DarkoDemo.DataServices.Base.Interfaces;
using DarkoDemo.Models;
using DarkoDemo.Services.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace DarkoDemo.Services;

public class BasketService(IRepository<Basket> repoBaskets, IRepository<BasketItem> repoBasketItems, IRepository<Product> repoProducts, IUnitOfWork unitOfWork) : BaseEntityService, IBasketService
{
    private readonly IRepository<Basket> _repoBaskets = repoBaskets;
    private readonly IRepository<BasketItem> _repoBasketItems = repoBasketItems;
    private readonly IRepository<Product> _repoProducts = repoProducts;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<BasketRead?> ReadBasket(Guid customerId)
    {
        var basketEntity = await _repoBaskets.Query()
            .Include(b => b.Items)
            .ThenInclude(i => i.Product)
            .FirstOrDefaultAsync(b => b.CustomerId == customerId);

        return basketEntity?.Adapt<BasketRead>();
    }

    public async Task<Basket?> GetBasket(Guid customerId)
    {
        return await _repoBaskets.Query()
            .AsNoTracking()
            .Include(b => b.Items)
            .FirstOrDefaultAsync(b => b.CustomerId == customerId);
    }

    public async Task<Basket> CreateBasket(Guid customerId)
    {
        Basket newBasket = new() { CustomerId = customerId };
        InitializeForCreate(newBasket);
        _repoBaskets.Create(newBasket);
        await _unitOfWork.SaveChanges();

        return newBasket;
    }

    public async Task<int> CreateBasketItem(Guid basketId, Guid productId)
    {
        var product = await _repoProducts.ReadOne(productId);
        BasketItem newBasketItem = new() { BasketId = basketId, ProductId = productId, Quantity = 1, UnitPrice = product!.Price };
        InitializeForCreate(newBasketItem);
        _repoBasketItems.Create(newBasketItem);
        return await _unitOfWork.SaveChanges();
    }
}
