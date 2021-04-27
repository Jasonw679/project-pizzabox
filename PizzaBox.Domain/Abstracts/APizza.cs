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
    public List<Order> Order { get; set; }
    protected static readonly CrustSingleton _crustSingleton = CrustSingleton.Instance;
    protected static readonly SizeSingleton _sizeSingleton = SizeSingleton.Instance;
    protected static readonly ToppingSingleton _toppingSingleton = ToppingSingleton.Instance;
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
      AddSize();
      AddToppings();
    }
    protected abstract void AddCrust();
    private void AddSize(Size size = null)
    {
      Size = size ?? _sizeSingleton.Sizes[1];
    }
    protected abstract void AddToppings();
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