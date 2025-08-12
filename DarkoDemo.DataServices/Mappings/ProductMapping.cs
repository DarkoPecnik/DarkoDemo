using DarkoDemo.Data;
using DarkoDemo.Models;
using Mapster;

namespace DarkoDemo.DataServices.Mappings;

public class ProductMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Product, ProductRead>()
            .Map(dest => dest.Categories,
                 src => src.ProductCategories.Select(pc => pc.Category));

        config.NewConfig<Category, CategoryRead>();

        config.NewConfig<ProductWrite, Product>()
           .Map(dest => dest.ProductCategories,
                src => src.CategoryIds.Select(id => new ProductCategory { CategoryId = id }));
    }
}
