namespace DarkoDemo.Data;

public class ProductCategory
{
    // Navigation
    public Guid ProductId { get; set; }

    public Product Product { get; set; } = default!;

    public Guid CategoryId { get; set; }

    public Category Category { get; set; } = default!;
}