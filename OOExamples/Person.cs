using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOExamples
{
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (value > 0 && value < 120) _age = value;
            }
        }

        public string FullName { 
            get { return $"{FirstName} {LastName}"; }
        }

        public virtual void myMethod()
        {
            Console.WriteLine("myMethod from Person class");
        }
    }
}
