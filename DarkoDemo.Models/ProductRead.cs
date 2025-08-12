namespace DarkoDemo.Models;

public class ProductRead
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public List<CategoryRead> Categories { get; set; } = default!;
}