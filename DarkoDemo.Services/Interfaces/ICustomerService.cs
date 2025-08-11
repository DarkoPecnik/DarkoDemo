using DarkoDemo.Data;
using DarkoDemo.Models;

namespace DarkoDemo.Services.Interfaces;

public interface ICustomerService
{
    Task<Customer?> GetCustomer(Guid customerId);

    Task<List<CustomerRead>> ReadCustomers();
}
