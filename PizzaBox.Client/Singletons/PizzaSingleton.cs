using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Singletons
{
  public class PizzaSingleton
  {
    public List<APizza> Pizzas { get; set; }
    private readonly PizzaBoxContext _context = new PizzaBoxContext();
    private static readonly PizzaSingleton _instance;
    public static PizzaSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          return new PizzaSingleton();
        }
        return _instance;
      }
    }
    private PizzaSingleton()
    {
      if (Pizzas == null)
      {
        _context.Pizzas.Add(new CheesePizza());
        _context.Pizzas.Add(new PepperoniPizza());
        // _context.SaveChanges();
        Pizzas = _context.Pizzas.ToList();
      }
    }
  }
}