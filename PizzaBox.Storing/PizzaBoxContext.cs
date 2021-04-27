using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing
{
  public class PizzaBoxContext : DbContext
  {
    private readonly IConfiguration _configuration;
    public DbSet<AStore> Stores { get; set; }
    public DbSet<APizza> Pizzas { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public PizzaBoxContext()
    {
      _configuration = new ConfigurationBuilder().AddUserSecrets<PizzaBoxContext>().Build();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer(_configuration["mssql"]);
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<AStore>().HasKey(e => e.EntityId);
      builder.Entity<JayPizza>().HasBaseType<AStore>();
      builder.Entity<Pizzaria>().HasBaseType<AStore>();
      builder.Entity<APizza>().HasKey(e => e.EntityId);
      builder.Entity<PepperoniPizza>().HasBaseType<APizza>();
      builder.Entity<CheesePizza>().HasBaseType<APizza>();
      builder.Entity<Crust>().HasKey(e => e.EntityId);
      builder.Entity<Customer>().HasKey(e => e.EntityId);
      builder.Entity<Order>().HasKey(e => e.EntityId);
      builder.Entity<Size>().HasKey(e => e.EntityId);
      builder.Entity<Topping>().HasKey(e => e.EntityId);

      builder.Entity<APizza>().HasOne<Crust>(s => s.Crust).WithMany(s => s.Pizzas);

      builder.Entity<APizza>().HasOne<Size>(s => s.Size).WithMany(s => s.Pizzas);

      builder.Entity<APizza>().HasMany<Topping>(s => s.Toppings).WithMany(s => s.Pizzas);
      builder.Entity<Topping>().HasMany<APizza>(s => s.Pizzas).WithMany(s => s.Toppings);

      builder.Entity<AStore>().HasMany<Order>(s => s.Orders).WithOne(o => o.Store);

      builder.Entity<APizza>().HasMany<Order>(s => s.Order).WithMany(s => s.pizzas);
      builder.Entity<Order>().HasMany<APizza>(s => s.pizzas).WithMany(s => s.Order);

      builder.Entity<Customer>().HasMany<Order>(s => s.orders).WithOne(s => s.Customer);

      OnDataSeeding(builder);
    }
    private void OnDataSeeding(ModelBuilder builder)
    {
      builder.Entity<JayPizza>().HasData(new JayPizza[]
      {
        new JayPizza() {EntityId = 1}
      });

      builder.Entity<Pizzaria>().HasData(new Pizzaria[]
      {
        new Pizzaria() {EntityId = 2}
      });

      //builder.Entity<CheesePizza>().HasData(new CheesePizza[]
      //{
      //new CheesePizza() {EntityId = 1, Crust = crust.Medium}
      //});

      //builder.Entity<PepperoniPizza>().HasData(new PepperoniPizza[]
      //{
      //new PepperoniPizza() {EntityId = 2, Crust = crust.Medium}
      //});
    }
  }
}