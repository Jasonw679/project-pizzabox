using PizzaBox.Domain.Models;
using PizzaBox.Domain.Singletons;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class CrustTests
  {
    [Fact]
    public void Test_Crust()
    {
      var value = new Crust("Test", 1.0f);
      Assert.Equal("Test", value.Name);
      Assert.Equal(1.0f, value.Price);
    }
    [Fact]
    public void SingletonsTest()
    {
      var t = CrustSingleton.Instance;
      Assert.Equal(3, t.Crusts.Count);
    }
  }
}