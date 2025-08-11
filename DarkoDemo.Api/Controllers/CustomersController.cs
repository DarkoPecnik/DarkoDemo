using DarkoDemo.Data;
using DarkoDemo.Models;
using DarkoDemo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DarkoDemo.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class CustomersController(ICustomerService customerService) : ControllerBase
{
    private readonly ICustomerService _customerService = customerService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerRead>>> GetCustomers()
    {
        return await _customerService.ReadCustomers();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetCustomer(Guid id)
    {
        var customer = await _customerService.GetCustomer(id);

        if (customer == null) return NotFound();

        return customer;
    }
}
