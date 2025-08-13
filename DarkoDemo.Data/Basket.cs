using DarkoDemo.Data.Base;

namespace DarkoDemo.Data;

public class Basket : IBaseEntity
{
    public Guid Id { get; set; }

    public string? Name { get; set; }


    // IBaseEntity
    public DateTimeOffset CreatedDate { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public bool Active { get; set; }


    // Navigation
    public Guid CustomerId { get; set; }

    public Customer Customer { get; set; } = default!;

    public ICollection<BasketItem> Items { get; set; } = [];
}