using DarkoDemo.Data;
using Microsoft.EntityFrameworkCore;

namespace DarkoDemo.DataServices.Extensions;

public static class ModelBuilderExtension
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var customers = new List<Customer>();

        for (int i = 1; i <= 10; i++)
        {
            customers.Add(new Customer
            {
                Id = Guid.CreateVersion7(),
                Name = $"Customer {i}",
                Email = $"customer{i}@fake.com",
                CreatedDate = DateTimeOffset.UtcNow,
                Active = true
            });
        }

        modelBuilder.Entity<Customer>().HasData(customers);
    }
}
