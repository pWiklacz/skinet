using System.Reflection;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class StoreContext : DbContext
{
  public StoreContext(DbContextOptions<StoreContext> options) : base(options)
  {
  }

  public DbSet<Product> Products { get; set; } = null!;
  public DbSet<ProductBrand> ProductBrands { get; set; } = null!;
  public DbSet<ProductType> ProductTypes { get; set; } = null!;
  public DbSet<Order> Orders { get; set; } = null!;
  public DbSet<OrderItem> OrderItems { get; set; } = null!;
  public DbSet<DeliveryMethod> DeliveryMethods { get; set; } = null!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
    {
      foreach (var entityType in modelBuilder.Model.GetEntityTypes())
      {
        var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));

        foreach (var property in properties)
        {
          modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();
        }
      }
    }
  }


}