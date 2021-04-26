using PizzaBox.Domain.Models;
using PizzaBox.Domain.Singletons;
using System.Collections.Generic;

namespace PizzaBox.Domain.Abstracts
{
  public abstract class APizza : AModel
  {
    public string Name { get; set; }
    public Crust Crust { get; set; }
    public Size Size { get; set; }
    public List<Topping> Toppings { get; set; }
    protected static readonly CrustSingleton _crustSingleton = CrustSingleton.Instance;
    public float Price
    {
      get
      {
        return computePrice();
      }
    }
    public APizza()
    {
      AddCrust();
      AddSize(new Size("Medium", 1.0f));
      AddToppings();
    }
    protected void AddCrust(Crust crust = null)
    {
      Crust = crust ?? _crustSingleton.Crusts.Find(x => x.Name.Equals("Medium"));
    }
    private void AddSize(Size size = null)
    {
      Size = size ?? Size.Medium;
    }
    protected void AddToppings(List<Topping> toppings = null)
    {
      Toppings = toppings ?? new List<Topping>();
    }
    public override string ToString()
    {
      return Name;
    }
    private float computePrice()
    {
      var price = 0.0f;
      foreach (Topping t in Toppings)
      {
        price += t.Price;
      }
      price += Crust.Price;
      price += Size.Price;
      return price;
    }
  }
}