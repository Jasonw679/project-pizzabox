using PizzaBox.Domain.Abstracts;
using System.Collections.Generic;
using System;


namespace PizzaBox.Domain.Models
{
  public class CustomPizza : APizza
  {
    public CustomPizza(Crust crust, List<Topping> toppings)
    {
      AddCrust(crust);
      Toppings = toppings;
      Name = "Custom Pizza";
    }
  }
}