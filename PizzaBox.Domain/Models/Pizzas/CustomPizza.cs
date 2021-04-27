using PizzaBox.Domain.Abstracts;
using System.Collections.Generic;
using System;


namespace PizzaBox.Domain.Models
{
  public class CustomPizza : APizza
  {
    public CustomPizza(Crust crust, List<Topping> toppings)
    {
      Crust = crust;
      Toppings = toppings;
      Name = "Custom Pizza";
    }
    protected override void AddCrust()
    {

    }
    protected override void AddToppings()
    {

    }
  }
}