using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    public class StoreTests
    {
        [Fact]
        public void Test_JayPizza()
        {
            var sut = new JayPizza();

            Assert.True(sut.Name.Equals("Jay Pizza"));
            Assert.True(sut.Name.Equals(sut));
        }

        [Fact]
        public void Test_Pizzaria()
        {
            var sut = new Pizzaria();

            Assert.True(sut.Name.Equals("Pizzaria"));
            Assert.True(sut.Name.Equals(sut));
        }
    }
}