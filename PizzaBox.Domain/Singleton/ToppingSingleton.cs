using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Singletons
{
  public class ToppingSingleton
  {
    public List<Topping> Toppings { get; set; }

    private static ToppingSingleton _instance;

    public static ToppingSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new ToppingSingleton();
        }
        return _instance;
      }
    }
    private ToppingSingleton()
    {
      Toppings = new List<Topping>()
        {
          new Topping("Mushroom", 0.1f),
          new Topping("Cheese", 0.2f),
          new Topping("Pepporina", 0.25f)
        };
    }
  }
}