using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class PizzaTests
  {
    [Fact]
    public void Test_PizzaConstructor()
    {
      var sut = new Pizza();

      Assert.NotNull(sut);
    }
  }
}