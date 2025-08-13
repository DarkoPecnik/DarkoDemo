namespace DarkoDemo.Models;

public class BasketRead
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public decimal Total => Items.Sum(i => i.UnitPrice * i.Quantity);

    public List<BasketItemRead> Items { get; set; } = [];
}