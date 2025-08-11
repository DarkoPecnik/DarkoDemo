using DarkoDemo.Data;
using DarkoDemo.DataServices.Base.Interfaces;
using DarkoDemo.Models;
using DarkoDemo.Services.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace DarkoDemo.Services;

public class CustomerService(IRepository<Customer> repoCustomers) : ICustomerService
{
    private readonly IRepository<Customer> _repoCustomers = repoCustomers;

    public async Task<Customer?> GetCustomer(Guid customerId)
    {
        return await _repoCustomers.GetOne(customerId);
    }

    public async Task<List<CustomerRead>> ReadCustomers()
    {
        return await _repoCustomers.Query().AsNoTracking().ProjectToType<CustomerRead>().ToListAsync();
    }
}
