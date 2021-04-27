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
      o.Store = _context.Stores.FirstOrDefault();
      _context.Orders.Add(o);
      _context.SaveChanges();
    }
  }
}