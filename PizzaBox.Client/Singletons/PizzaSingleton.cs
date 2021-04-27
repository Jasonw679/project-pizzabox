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
    private static readonly PizzaSingleton _instance;
    public static PizzaSingleton Instance(PizzaBoxContext context)
    {
      if (_instance == null)
      {
        return new PizzaSingleton(context);
      }
      return _instance;
    }
    private PizzaSingleton(PizzaBoxContext context)
    {
      Pizzas = context.Pizzas.ToList();
      if (Pizzas.Count == 0)
      {
        context.Pizzas.Add(new CheesePizza());
        context.Pizzas.Add(new PepperoniPizza());
        context.SaveChanges();
        Pizzas = context.Pizzas.ToList();
      }
    }
  }
}