using PizzaBox.Domain.Models;
using PizzaBox.Domain.Singletons;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class CrustTests
  {
    public Crust value = new Crust("Test", 1.0f);
    [Fact]
    public void Test_Crust_Name()
    {
      Assert.Equal("Test", value.ToString());
    }
    [Fact]
    public void Test_Crust_Price()
    {
      Assert.Equal(1.0f, value.Price);
    }
  }
}