namespace DarkoDemo.Shared.Core;

public static class Routes
{
    public const string Home = "/";
    public const string Store = "/store";
    public const string Basket = "/basket/{CustomerId:guid}";

    public static string GetBasketRoute(Guid customerId) => $"/basket/{customerId}";

    public static class Admin
    {
        public const string Customer = "/customer/{Id:guid}";
        public const string Customers = "/customers";
        public const string Categories = "/categories";
        public const string Products = "/products";
        public const string AddProduct = "/products/add";

        public static string GetCustomerRoute(Guid customerId) => $"/customer/{customerId}";
    }
}
