using DarkoDemo.Data.Base;

namespace DarkoDemo.Data;

public class Category : IBaseEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;


    // IBaseEntity
    public DateTimeOffset CreatedDate { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public bool Active { get; set; }


    // Navigation
    public ICollection<ProductCategory> ProductCategories { get; set; } = [];
}