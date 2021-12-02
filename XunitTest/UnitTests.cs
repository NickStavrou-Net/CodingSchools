using System;
using xUnit;
using Xunit;

namespace XunitTest
{
   public class UnitTests
   {
      Product p;

      public UnitTests()
      {
         p = new Product();
      }


      // [Fact(Skip ="Test skip")]
      [Fact]
      public void CheckThatFinalPriceWithVATIsCorrect()
      {
         p.Price = 100;
         Assert.Equal(124.0, p.GetPriceWithVAT(0.24));

      }

      [Theory]
      [InlineData(0.24)]
      [InlineData(0.25)]
      [InlineData(0.26)]
      public void CheckFinalPrice2(double vat)
      {
         p.Price = 100;
         Assert.Equal(124.0, p.GetPriceWithVAT(vat));
      }
   }
}
