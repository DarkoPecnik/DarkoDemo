using DarkoDemo.Data;
using DarkoDemo.Models;
using DarkoDemo.Services.Enums;
using DarkoDemo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace DarkoDemo.CatalogApi.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriesController(ICategoryService categoryService, IMemoryCache cache) : ControllerBase
{
    private readonly ICategoryService _categoryService = categoryService;
    private readonly IMemoryCache _cache = cache;

    private const string CategoriesCacheKey = "CategoriesCache";

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        if (!_cache.TryGetValue(CategoriesCacheKey, out List<Category>? categories))
        {
            categories = await _categoryService.ReadCategories();
            _cache.Set(CategoriesCacheKey, categories, TimeSpan.FromMinutes(5));
        }

        return Ok(categories);
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory(CategoryWrite category)
    {
        await _categoryService.CreateCategory(category);
        _cache.Remove(CategoriesCacheKey);

        return CreatedAtAction(nameof(GetCategories), category);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        switch (await _categoryService.DeleteCategory(id))
        {
            case DeleteResult.Success:
                _cache.Remove(CategoriesCacheKey);
                return NoContent();
            default:
                return NotFound();
        }
    }
}
