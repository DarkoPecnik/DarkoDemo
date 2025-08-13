using DarkoDemo.Data;
using DarkoDemo.Models;
using Mapster;

namespace DarkoDemo.DataServices.Mappings;

public class BasketMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Basket, BasketRead>()
            .Map(dest => dest.Items,
                 src => src.Items);

        config.NewConfig<BasketItem, BasketItemRead>()
            .Map(dest => dest.Product,
                 src => src.Product);
    }
}
