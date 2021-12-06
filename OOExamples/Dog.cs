using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOExamples
{
    class Dog : Animal, ISwimmable, IRunnable
    {
        public void myMethod()
        {
            Console.WriteLine("IRunnable.myMethod implementation");
        }

        void ISwimmable.myMethod()
        {
            Console.WriteLine("ISwimmable.myMethod implementation");
        }

        public void run()
        {
            Console.WriteLine("Dog runs...");
        }

        public void swim()
        {
            Console.WriteLine("Dog swims...");
        }
    }
}
