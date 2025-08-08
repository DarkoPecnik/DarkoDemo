using DarkoDemo.Data.Enums;

namespace DarkoDemo.Data;

public class Order
{
    public Guid Id { get; set; }

    public DateTimeOffset OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    public OrderStatus Status { get; set; }


    // Navigation
    public Guid CustomerId { get; set; }

    public Customer Customer { get; set; } = default!;

    public ICollection<OrderItem> Items { get; set; } = [];
}