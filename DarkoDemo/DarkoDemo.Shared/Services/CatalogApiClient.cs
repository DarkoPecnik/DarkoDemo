using DarkoDemo.Data;
using DarkoDemo.Models;
using System.Net.Http.Json;

namespace DarkoDemo.Shared.Services;

public class CatalogApiClient(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<IEnumerable<ProductRead>?> ReadProducts()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<ProductRead>>("products");
    }

    public async Task AddProduct(ProductWrite product)
    {
        await _httpClient.PostAsJsonAsync("products", product);
    }

    public async Task DeleteProduct(Guid id)
    {
        await _httpClient.DeleteAsync($"products/{id}");
    }

    public async Task<IEnumerable<Category>?> ReadCategories()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Category>>("categories");
    }

    public async Task AddCategory(CategoryWrite category)
    {
        await _httpClient.PostAsJsonAsync("categories", category);
    }

    public async Task DeleteCategory(Guid id)
    {
        await _httpClient.DeleteAsync($"categories/{id}");
    }
}