using DarkoDemo.Models;
using DarkoDemo.Services.Enums;

namespace DarkoDemo.Services.Interfaces;

public interface IProductService
{
    Task<List<ProductRead>> ReadProducts();

    Task<int> CreateProduct(ProductWrite product);

    Task<DeleteResult> DeleteProduct(Guid id);
}
