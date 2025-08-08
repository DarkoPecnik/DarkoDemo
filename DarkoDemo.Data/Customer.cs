using DarkoDemo.Data.Base;

namespace DarkoDemo.Data;

public class Customer : IBaseEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string Secret { get; set; } = default!;


    // IBaseEntity
    public DateTimeOffset CreatedDate { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public bool Active { get; set; }


    // Navigation
    public ICollection<Basket> Baskets { get; set; } = [];

    public ICollection<Order> Orders { get; set; } = [];
}