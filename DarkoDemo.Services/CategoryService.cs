using DarkoDemo.Data;
using DarkoDemo.DataServices.Base.Interfaces;
using DarkoDemo.Models;
using DarkoDemo.Services.Enums;
using DarkoDemo.Services.Interfaces;
using Mapster;

namespace DarkoDemo.Services;

public class CategoryService(IRepository<Category> repoCategories, IUnitOfWork unitOfWork) : BaseEntityService, ICategoryService
{
    private readonly IRepository<Category> _repoCategories = repoCategories;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<List<Category>> ReadCategories()
    {
        return await _repoCategories.ReadAll();
    }

    public async Task<int> CreateCategory(CategoryWrite categoryWrite)
    {
        var newCategory = categoryWrite.Adapt<Category>();
        InitializeForCreate(newCategory);
        _repoCategories.Create(newCategory);
        return await _unitOfWork.SaveChanges();
    }

    public async Task<DeleteResult> DeleteCategory(Guid id)
    {
        var category = await _repoCategories.GetOne(id);
        if (category is null) return DeleteResult.NotFound;
        _repoCategories.Delete(category);
        return await _unitOfWork.SaveChanges() > 0 ? DeleteResult.Success : DeleteResult.Failure;
    }
}
