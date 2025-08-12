using DarkoDemo.Data;
using DarkoDemo.DataServices.Base.Interfaces;
using DarkoDemo.Models;
using DarkoDemo.Services.Enums;
using DarkoDemo.Services.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace DarkoDemo.Services;

public class ProductService(IRepository<Product> repoProducts, IUnitOfWork unitOfWork) : BaseEntityService, IProductService
{
    private readonly IRepository<Product> _repoProducts = repoProducts;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<List<ProductRead>> ReadProducts()
    {
        return await _repoProducts.Query()
            .AsNoTracking()
            .ProjectToType<ProductRead>()
            .ToListAsync();
    }

    public async Task<int> CreateProduct(ProductWrite productWrite)
    {
        var newProduct = productWrite.Adapt<Product>();
        InitializeForCreate(newProduct);
        _repoProducts.Create(newProduct);
        return await _unitOfWork.SaveChanges();
    }

    public async Task<DeleteResult> DeleteProduct(Guid id)
    {
        var product = await _repoProducts.GetOne(id);
        if (product is null) return DeleteResult.NotFound;
        _repoProducts.Delete(product);
        return await _unitOfWork.SaveChanges() > 0 ? DeleteResult.Success : DeleteResult.Failure;
    }
}
