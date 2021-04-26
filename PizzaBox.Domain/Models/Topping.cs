using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Topping : AModel
  {
    public List<APizza> Pizzas = new List<APizza>();
    public static readonly Topping Cheese = new Topping("Cheese", 0.2f);
    public static readonly Topping Pepperoni = new Topping("Pepporina", 0.25f);

    public Topping(string Name, float Price)
    {
      this.Name = Name;
      this.Price = Price;
    }
    public string Name { get; set; }
    public float Price { get; set; }
  }
}