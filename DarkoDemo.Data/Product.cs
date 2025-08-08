using DarkoDemo.Data.Base;

namespace DarkoDemo.Data;

public class Product : IBaseEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }


    // IBaseEntity
    public DateTimeOffset CreatedDate { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public bool Active { get; set; }


    // Navigation
    public ICollection<ProductCategory> ProductCategories { get; set; } = [];


    // Optional
    public ICollection<BasketItem> BasketItems { get; set; } = [];

    public ICollection<OrderItem> OrderItems { get; set; } = [];
}