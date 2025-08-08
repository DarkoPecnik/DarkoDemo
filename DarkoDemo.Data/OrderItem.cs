using DarkoDemo.Data.Base;

namespace DarkoDemo.Data;

public class OrderItem : IBaseEntity
{
    public Guid Id { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }


    // IBaseEntity
    public DateTimeOffset CreatedDate { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public bool Active { get; set; }


    // Navigation
    public Guid OrderId { get; set; }

    public Order Order { get; set; } = default!;

    public Guid ProductId { get; set; }

    public Product Product { get; set; } = default!;
}