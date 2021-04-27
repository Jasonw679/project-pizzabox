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

    protected override void AddCrust()
    {
      Crust = _crustSingleton.Medium;
    }

    protected override void AddToppings()
    {
      Toppings = new List<Topping>()
      {
        _toppingSingleton.Pepperoni
      };
    }
  }
}