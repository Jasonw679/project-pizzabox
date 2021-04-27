using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Size : AModel
  {
    public ICollection<APizza> Pizzas { get; set; }
    public Size(string Name, float Price)
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