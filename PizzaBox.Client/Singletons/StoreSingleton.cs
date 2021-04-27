using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Singletons
{
  public class StoreSingleton
  {
    public List<AStore> Stores { get; set; }
    private readonly PizzaBoxContext _context;
    private static StoreSingleton _instance;

    public static StoreSingleton Instance(PizzaBoxContext context)
    {
      if (_instance == null)
      {
        _instance = new StoreSingleton(context);
      }
      return _instance;
    }
    private StoreSingleton(PizzaBoxContext context)
    {
      _context = context;
      Stores = _context.Stores.ToList();
      if (Stores.Count == 0)
      {
        _context.Stores.Add(new JayPizza());
        _context.Stores.Add(new Pizzaria());
        _context.SaveChanges();

        Stores = _context.Stores.ToList();
      }
    }
    public IEnumerable<AStore> ViewOrders(AStore store)
    {
      var orders = _context.Stores.Include(s => s.Orders).ThenInclude(o => o.pizzas).Where(s => s.Name == store.Name);
      return orders.ToList();
    }
  }
}