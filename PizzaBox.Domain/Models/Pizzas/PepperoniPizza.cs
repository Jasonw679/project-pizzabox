using PizzaBox.Domain.Abstracts;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class PepperoniPizza : APizza
  {

    public PepperoniPizza()
    {
      Name = "Pepperoni Pizza";
    }

    protected void AddCrust()
    {
      Crust = _crustSingleton.Medium;
    }

    protected void AddToppings()
    {
      Toppings = new List<Topping>()
      {
        Topping.Pepperoni
      };
    }
  }
}