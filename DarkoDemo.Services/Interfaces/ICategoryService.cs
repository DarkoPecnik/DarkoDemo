using DarkoDemo.Data;
using DarkoDemo.Models;
using DarkoDemo.Services.Enums;

namespace DarkoDemo.Services.Interfaces;

public interface ICategoryService
{
    Task<List<Category>> ReadCategories();

    Task<int> CreateCategory(CategoryWrite category);

    Task<DeleteResult> DeleteCategory(Guid id);
}
