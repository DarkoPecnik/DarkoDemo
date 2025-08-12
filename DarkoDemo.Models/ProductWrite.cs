namespace DarkoDemo.Models;

public class ProductWrite
{
    public string Name { get; set; } = default!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public List<Guid> CategoryIds { get; set; } = [];
}
