using PizzaBox.Domain.Models;
using PizzaBox.Domain.Singletons;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class SizeTests
  {
    [Fact]
    public void Test_Size()
    {
      var value = new Size("Test", 1.0f);
      Assert.Equal("Test", value.Name);
      Assert.Equal(1.0f, value.Price);
    }
    [Fact]
    public void SingletonsTest()
    {
      var t = SizeSingleton.Instance;
      Assert.Equal(3, t.Sizes.Count);
    }
  }
}