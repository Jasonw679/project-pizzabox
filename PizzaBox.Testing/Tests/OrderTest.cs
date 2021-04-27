using PizzaBox.Domain.Models;
using PizzaBox.Domain.Abstracts;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class OrderTest
  {
    [Fact]
    public void Test_Order()
    {
      var o = new Order();
      o.pizzas.Add(new CheesePizza());
      o.pizzas.Add(new PepperoniPizza());
      o.Customer = new Customer() { Name = "test" };
      Assert.Equal(o.pizzas.Count, 2);
      Assert.Equal(o.Customer.Name, "test");
    }
  }
}