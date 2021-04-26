using PizzaBox.Domain.Models;
using PizzaBox.Domain.Singletons;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class ToppingTests
  {
    [Fact]
    public void Test_Topping()
    {
      var value = new Topping("Test", 1.2f);
      Assert.Equal("Test", value.Name);
      Assert.Equal(1.2f, value.Price);
    }
    [Fact]
    public void SingletonsTest()
    {
      var t = ToppingSingleton.Instance;
      Assert.Equal(3, t.Toppings.Count);
    }
  }
}