using PizzaBox.Domain.Abstracts;
using System;


namespace PizzaBox.Domain.Models
{
  public class CustomPizza : APizza
  {

    //private static readonly CrustSingleton _crustSingleton = CrustSingleton.Instance;
    public CustomPizza()
    {
      Name = "Custom Pizza";
    }
    protected override void AddCrust()
    {
      Console.WriteLine("Choose a Crust");
      _crustSingleton.PrintCrustList();
      Crust = _crustSingleton.Crusts[int.Parse(Console.ReadLine())];
    }
    protected override void AddToppings()
    {
      for (int i = 0; i < 2; i++)
      {
        AddTopping();
      }
      var input = "";
      do
      {
        Console.WriteLine("Add another topping? Y/N");
        input = Console.ReadLine();
        if (input.Equals("Y"))
        {
          AddTopping();
        }
      } while (input.Equals("N") || Toppings.Count > 4);
    }
    private void AddTopping()
    {
      Console.WriteLine("Add a topping");
      Topping.PrintToppingList();
      Toppings.Add(Topping.ToppingList[int.Parse(Console.ReadLine())]);
    }

  }
}