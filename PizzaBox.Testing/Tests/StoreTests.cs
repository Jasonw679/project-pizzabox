using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;
using System.Collections.Generic;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class StoreTests
  {
    public static IEnumerable<object[]> values = new List<object[]>()
        {
            new object[] { new JayPizza() },
            new object[] { new Pizzaria() }
        };
    [Theory]
    [MemberData(nameof(values))]
    public void Test_StoreName(AStore store)
    {
      Assert.NotNull(store.Name);
      Assert.Equal(store.Name, store.ToString());
    }
    [Fact]
    public void Test_Singleton()
    {
      var s = StoreSingleton.Instance;
      Assert.Equal(s.Stores.Count, 2);
    }
  }
}