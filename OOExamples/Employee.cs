using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOExamples
{
    public class Employee : Person
    {
        public double Salary { get; set; }
        public override string ToString()
        {
            return $"This is an Employee: {base.FullName}";
        }

        public override void myMethod()
        {
            Console.WriteLine("myMethod from Employee class");
        }
    }
}
