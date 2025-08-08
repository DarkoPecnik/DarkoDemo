namespace DarkoDemo.Data.Base;

public interface IBaseEntity
{
    public Guid Id { get; set; }

    public DateTimeOffset CreatedDate { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public bool Active { get; set; }
}
