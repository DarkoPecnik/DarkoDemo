namespace DarkoDemo.Models;

public class BasketItemRead
{
    public Guid Id { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal SubTotal => Quantity * UnitPrice;

    public ProductRead Product { get; set; } = default!;
}