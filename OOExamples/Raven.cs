using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOExamples
{
   public class Raven : Bird, IFlyable
   {
      public void fly()
      {
         Console.WriteLine("Raven flies...");
      }
   }
}
