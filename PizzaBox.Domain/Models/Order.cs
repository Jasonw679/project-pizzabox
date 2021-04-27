using PizzaBox.Domain.Abstracts;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class Order : AModel
  {
    public AStore Store { get; set; }
    public List<APizza> pizzas = new List<APizza>();
    public Customer Customer { get; set; }
    public long CustomerEntityId { get; set; }
    public override string ToString()
    {
      double price = 0.0;
      string result = "";
      for (var i = 0; i < pizzas.Count; i += 1)
      {
        if (i > 0)
        {
          result += ", ";
        }
        if (i == pizzas.Count - 1 && pizzas.Count > 1)
        {
          result += "and ";
        }
        result += pizzas[i] + $" in {pizzas[i].Crust} crust with";
        foreach (var top in pizzas[i].Toppings)
        {
          result += $" {top}";
        }
        result += "\n";
        price += pizzas[i].Price;
      }
      return $"{result} order in {Store}, Final Price: {price}";
    }
    public void PrintOrderedPizzas()
    {
      for (int i = 0; i < pizzas.Count; i += 1)
      {
        var v = pizzas[i];
        System.Console.WriteLine($"{i} {v}");
      }
    }
  }
}