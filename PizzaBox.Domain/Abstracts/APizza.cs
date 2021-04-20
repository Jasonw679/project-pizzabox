using PizzaBox.Domain.Enums;
using PizzaBox.Domain.Models;
using System.Collections.Generic;

namespace PizzaBox.Domain.Abstracts
{
  public abstract class APizza : AModel
  {
    public string Name { get; set; }
    protected Crust Crust;
    protected Size Size;
    protected List<Topping> Toppings;
    public float Price
    {
      get
      {
        return computePrice();
      }
    }
    public APizza()
    {
      //CrustEnum = CrustEnum.ThickCrust;
      AddCrust();
      AddSize();
      AddToppings();
    }
    protected abstract void AddCrust();
    protected void AddSize()
    {
      Size = new Size("Medium", 1.0f);
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