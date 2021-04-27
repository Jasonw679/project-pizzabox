using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
  public class Customer : AModel
  {
    public string Name { get; set; }
    public List<Order> orders = new List<Order>();

    public override string ToString()
    {
      return Name;
    }
  }
}