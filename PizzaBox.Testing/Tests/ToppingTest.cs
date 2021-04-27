using PizzaBox.Domain.Models;
using PizzaBox.Domain.Singletons;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class ToppingTests
  {
    private Topping value = new Topping("Test", 1.2f);
    [Fact]
    public void Test_Topping_Name()
    {
      Assert.Equal("Test", value.ToString());
    }
    public void Test_Topping_Price()
    {
      Assert.Equal(1.2f, value.Price);
    }
  }
}