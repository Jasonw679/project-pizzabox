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
      Assert.NotNull(pizza.Name);
      Assert.Equal(pizza.Name, pizza.ToString());
    }
    [Fact]
    public void Test_PizzaPrice()
    {
      Assert.Equal(new CheesePizza().Price, 2.2);
      Assert.Equal(new PepperoniPizza().Price, 2.25);
    }
  }
}