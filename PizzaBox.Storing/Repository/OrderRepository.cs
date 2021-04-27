using PizzaBox.Domain.Models;
using System.Linq;

namespace PizzaBox.Storing.Repository
{
  public class OrderRepository
  {
    private readonly PizzaBoxContext _context;

    public OrderRepository(PizzaBoxContext context)
    {
      _context = context;
    }
    public void Save(Order o)
    {
      foreach (var p in o.pizzas)
      {
        p.Crust = _context.Pizzas.FirstOrDefault(Pizzas => Pizzas.Crust.Name.Equals(p.Crust.Name)).Crust;
        p.Size = _context.Pizzas.FirstOrDefault(Pizzas => Pizzas.Size.Name.Equals(p.Size.Name)).Size;
      }
      _context.Orders.Add(o);
      _context.SaveChanges();
    }
  }
}