using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Singletons;

namespace PizzaBox.Storing
{
  public class PizzaBoxContext : DbContext
  {
    private readonly IConfiguration _configuration;
    public DbSet<AStore> Stores { get; set; }
    public DbSet<APizza> Pizzas { get; set; }
    public DbSet<Order> Orders { get; set; }

    private CrustSingleton crust = CrustSingleton.Instance;

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

      builder.Entity<Crust>().HasMany<APizza>().WithOne();
      builder.Entity<APizza>().HasOne<Crust>().WithMany();

      builder.Entity<Size>().HasMany<APizza>().WithOne();
      builder.Entity<APizza>().HasOne<Size>().WithMany();

      //builder.Entity<APizza>().HasMany<Topping>().WithMany(s => s.Pizzas);
      //builder.Entity<Topping>().HasMany<APizza>().WithMany(s => s.Toppings);


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

      builder.Entity<CheesePizza>().HasData(new CheesePizza[]
      {
        new CheesePizza() {EntityId = 1, Crust = crust.Medium}
      });

      builder.Entity<PepperoniPizza>().HasData(new PepperoniPizza[]
      {
        new PepperoniPizza() {EntityId = 2, Crust = crust.Medium}
      });
    }
  }
}