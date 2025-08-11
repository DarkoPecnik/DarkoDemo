using DarkoDemo.Data;
using DarkoDemo.Models;
using System.Net.Http.Json;

namespace DarkoDemo.Shared.Services;

public class CoreApiClient(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<IEnumerable<CustomerRead>?> ReadCustomers()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<CustomerRead>>("customers");
    }

    public async Task<Customer?> GetCustomer(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<Customer>($"customers/{id}");
    }
}
