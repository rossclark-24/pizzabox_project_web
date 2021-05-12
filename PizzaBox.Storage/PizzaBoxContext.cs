using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Stores;

namespace PizzaBox.Storage
{
  public class PizzaBoxContext : DbContext
  {
    public DbSet<Crust> Crusts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<Topping> Toppings { get; set; }
    public DbSet<AStore> Stores { get; set; }

    public PizzaBoxContext(DbContextOptions options) : base(options) { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Crust>().HasKey(e => e.EntityId);
      builder.Entity<Order>().HasKey(e => e.EntityId);
      builder.Entity<Pizza>().HasKey(e => e.EntityId);
      builder.Entity<Size>().HasKey(e => e.EntityId);
      builder.Entity<Topping>().HasKey(e => e.EntityId);
      builder.Entity<AStore>().HasKey(e => e.EntityId);

      builder.Entity<AStore>().HasMany<Order>(s => s.Orders).WithOne(o => o.Store);
      //builder.Entity<Customer>().HasMany<Order>().WithOne(o => o.Customer);
      //builder.Entity<APizza>().HasMany<Order>().WithOne(o => o.Pizza);

      builder.Entity<ChicagoStore>().HasBaseType<AStore>();
      builder.Entity<NewYorkStore>().HasBaseType<AStore>();

      OnModelSeeding(builder);
    }

    private static void OnModelSeeding(ModelBuilder builder)
    {
      builder.Entity<Crust>().HasData(new[]
      {
        new Crust() { EntityId = 1, Name = "original" },
        new Crust() { EntityId = 2, Name = "stuffed" },
        new Crust() { EntityId = 3, Name = "flatbread" },
      });

      builder.Entity<Size>().HasData(new[]
      {
        new Size() { EntityId = 1, Name = "small" },
        new Size() { EntityId = 2, Name = "medium" },
        new Size() { EntityId = 3, Name = "large"}
      });

      builder.Entity<Topping>().HasData(new[]
      {
        new Topping() { EntityId = 1, Name = "pepperoni" },
        new Topping() { EntityId = 2, Name = "pineapple" },
        new Topping() { EntityId = 3, Name = "ham" },
        new Topping() { EntityId = 4, Name = "green peppers" },
        new Topping() { EntityId = 5, Name = "black olives" }
      });

      builder.Entity<ChicagoStore>().HasData(new[]
      {
        new ChicagoStore() { EntityId = 1, Name = "Downtown Chicago"}
      });
      builder.Entity<NewYorkStore>().HasData(new[]
      {
        new NewYorkStore() { EntityId = 2, Name = "Big Apple"}
      });

    
    }
  }
}
