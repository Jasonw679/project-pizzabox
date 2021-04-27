using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Singletons
{
  public class ToppingSingleton
  {
    public readonly Topping Cheese = new Topping("Cheese", 0.2f);
    public readonly Topping Pepperoni = new Topping("Pepporina", 0.25f);
    public readonly Topping TomatoSauce = new Topping("Tomato Sauce", 0.2f);
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
          new Topping("Onion", 0.1f),
          new Topping("Mushroom", 0.1f),
          Cheese,
          Pepperoni,
          TomatoSauce
        };
    }
  }
}