using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Singletons
{
  public class PizzaSingleton
  {
    public List<APizza> Pizzas { get; set; }

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
      Pizzas = new List<APizza>()
      {
        new PepperoniPizza(),
        new CheesePizza()
      };
    }
  }
}