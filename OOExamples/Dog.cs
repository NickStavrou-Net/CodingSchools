using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOExamples
{
    class Dog : Mammal, ISwimmable, IRunnable
    {
        public void myMethod()
        {
            Console.WriteLine("IRunnable.myMethod implementaion");
        }

        void ISwimmable.myMethod()
        {
            Console.WriteLine("ISwimmable.myMethod implementaion");
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
