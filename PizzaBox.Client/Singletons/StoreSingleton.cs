using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Singletons
{
  public class StoreSingleton
  {
    public List<AStore> Stores { get; set; }
    private readonly PizzaBoxContext _context = new PizzaBoxContext();
    private static StoreSingleton _instance;

    public static StoreSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new StoreSingleton();
        }
        return _instance;
      }
    }
    private StoreSingleton()
    {
      if (Stores == null)
      {
        _context.Stores.Add(new JayPizza());
        _context.Stores.Add(new Pizzaria());
        _context.SaveChanges();

        Stores = _context.Stores.ToList();
      }
    }
    //public IEnumerable<Order> ViewOrders(AStore store)
    //{
    //var orders = _context.Stores.Includes(s => Order >.Where(s => s.Name == store.Name);
    //}
  }
}