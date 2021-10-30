using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOExamples
{
    public class Student : Person
    {
        public override string ToString()
        {
            return $"This is a Student: {base.FullName}";
        }

        public new void myMethod()
        {
            Console.WriteLine("myMethod from Student class");
        }
    }
}
