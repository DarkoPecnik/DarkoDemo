namespace DarkoDemo.Shared.Services;

public class CustomerSwitcherService
{
    public event Action<Guid>? CustomerChanged;

    private Guid _currentCustomerId;

    public Guid CurrentCustomerId
    {
        get => _currentCustomerId;
        set
        {
            if (_currentCustomerId != value)
            {
                _currentCustomerId = value;
                CustomerChanged?.Invoke(value);
            }
        }
    }

    public void SetCustomer(Guid customerId)
    {
        CurrentCustomerId = customerId;
    }
}
