using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnit
{
   public class Product
   {
      public double Price { get; set; }

      public double GetPriceWithVAT(double vat)
      {
         return Price + (Price * vat);
      }
   }
}
