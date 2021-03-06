using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System.Collections.Generic;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class PizzaTests
  {
    public static IEnumerable<object[]> values = new List<object[]>()
        {
            new object[] { new CheesePizza() },
            new object[] { new PepperoniPizza() }
        };
    [Theory]
    [MemberData(nameof(values))]
    public void Test_PizzaName(APizza pizza)
    {
      Assert.Equal(pizza.Name, pizza.ToString());
    }
    [Fact]
    public void Test_PizzaPrice()
    {
      Assert.Equal(new CheesePizza().Price, 2.4);
      Assert.Equal(new PepperoniPizza().Price, 2.45);
    }
  }
}