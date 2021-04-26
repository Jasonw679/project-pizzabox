using PizzaBox.Domain.Abstracts;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class CheesePizza : APizza
  {
    public CheesePizza()
    {
      Name = "Cheese Pizza";
    }

    protected void AddCrust()
    {
      Crust = _crustSingleton.Medium;
    }
    protected void AddTopping()
    {
      Toppings = new List<Topping>()
        {
            Topping.Cheese
        };
    }
  }
}