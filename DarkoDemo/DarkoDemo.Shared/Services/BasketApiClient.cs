using DarkoDemo.Models;
using System.Net.Http.Json;

namespace DarkoDemo.Shared.Services;

public class BasketApiClient(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<BasketRead?> GetBasket(Guid customerId)
    {
        var response = await _httpClient.GetAsync($"basket/{customerId}");

        if (!response.IsSuccessStatusCode) return null;

        return await response.Content.ReadFromJsonAsync<BasketRead>();
    }

    public async Task<bool> AddToBasket(Guid productId, Guid customerId)
    {
        var response = await _httpClient.PostAsync($"basket/{productId}?customerId={customerId}", null);

        return response.IsSuccessStatusCode;
    }
}