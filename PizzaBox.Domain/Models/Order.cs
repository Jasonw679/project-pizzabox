using PizzaBox.Domain.Abstracts;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class Order : AModel
  {
    public AStore store { get; set; }
    public List<APizza> pizzas = new List<APizza>();
    public Customer customer { get; set; }
    public override string ToString()
    {
      float price = 0.0f;
      string result = "";
      for (int i = 0; i < pizzas.Count; i += 1)
      {
        if (i > 0)
        {
          result += ", ";
        }
        if (i == pizzas.Count - 1 && pizzas.Count > 1)
        {
          result += "and ";
        }
        result += pizzas[i];
        price += pizzas[i].Price;
      }
      return $"{result} order in {store}, Final Price: {price}";
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