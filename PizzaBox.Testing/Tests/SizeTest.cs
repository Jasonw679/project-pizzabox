using PizzaBox.Domain.Models;
using PizzaBox.Domain.Singletons;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class SizeTests
  {
    private Size value = new Size("Test", 1.0f);
    [Fact]
    public void Test_Size()
    {
      Assert.Equal("Test", value.ToString());
    }
    [Fact]
    public void Test_Price()
    {
      Assert.Equal(1.0f, value.Price);
    }
  }
}