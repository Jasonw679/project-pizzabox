using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class Crust
  {
    public static readonly Crust Thin = new Crust("Thin", 0.75f);
    public static readonly Crust Medium = new Crust("Medium", 1.0f);
    public static readonly Crust Thick = new Crust("Thick", 1.25f);
    public Crust(string Name, float Price)
    {
      this.Name = Name;
      this.Price = Price;
    }
    public string Name { get; set; }
    public float Price { get; set; }
  }
}