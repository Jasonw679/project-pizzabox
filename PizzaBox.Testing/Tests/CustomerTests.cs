using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System.Collections.Generic;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class CustomersTests
  {
    public static IEnumerable<object[]> values = new List<object[]>()
        {
            new object[] { new Customer(){Name = "Test"} },
        };
    [Theory]
    [MemberData(nameof(values))]
    public void Test_CustomersName(Customer customer)
    {
      Assert.NotNull(customer.Name);
      Assert.Equal(customer.Name, customer.ToString());
    }
  }
}