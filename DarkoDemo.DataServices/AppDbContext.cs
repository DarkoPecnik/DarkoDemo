using DarkoDemo.Data;
using DarkoDemo.DataServices.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DarkoDemo.DataServices;

internal class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        modelBuilder.Seed();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }

    public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<Basket> Baskets => Set<Basket>();

    public DbSet<BasketItem> BasketItems => Set<BasketItem>();

    public DbSet<Product> Products => Set<Product>();

    public DbSet<Category> Categories => Set<Category>();

    public DbSet<Order> Orders => Set<Order>();

    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
}
