using DarkoDemo.Data;
using Microsoft.EntityFrameworkCore;

namespace DarkoDemo.DataServices.Extensions;

public static class ModelBuilderExtension
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var customers = new List<Customer>();

        for (int i = 1; i <= 9; i++)
        {
            customers.Add(new Customer
            {
                Id = Guid.Parse($"d1a6f6a7-1b33-4a17-b78c-00000000000{i}"),
                Name = $"Customer {i}",
                Email = $"customer{i}@fake.com",
                CreatedDate = new DateTimeOffset(2025, 01, 01, 0, 0, 0, TimeSpan.Zero),
                Active = true
            });
        }

        modelBuilder.Entity<Customer>().HasData(customers);
    }
}
