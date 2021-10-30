using System;
using System.Linq;

namespace BasicLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ages = new int[] { 8, 10, 12, 16, 18, 25, 30, 42, 59, 70 };
            int countAdults = (from age in ages where age >= 18 select age).Count();


            int maxAdultAge = (from age in ages where age >= 18 select age).Max();
            int minAdultAge = (from age in ages where age >= 18 select age).Min();
            double avgAge = (from age in ages select age).Average();

        }
    }
}
