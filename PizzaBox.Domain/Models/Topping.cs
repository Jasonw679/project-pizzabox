using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Topping : AModel
  {
    public List<APizza> Pizzas = new List<APizza>();

    public Topping(string Name, float Price)
    {
      this.Name = Name;
      this.Price = Price;
    }
    public string Name { get; set; }
    public float Price { get; set; }

    public override string ToString()
    {
      return Name;
    }
  }
}