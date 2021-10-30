using System;
using System.Collections.Generic;

namespace OOExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Employee { FirstName="George", LastName="Sovatzis", Age=41, Salary=1000 };
            Person p2 = new Student { FirstName="Nikos", LastName = "Stavrou", Age=25 };
            Student p3 = new Student { FirstName = "Panos", LastName = "Sovatzis", Age=30 };

            p1.myMethod();
            p2.myMethod();
            p3.myMethod();

            List<Person> persons = new List<Person>();
            persons.Add(p1);
            persons.Add(p2);
            persons.Add(p3);

            foreach(Person p in persons)
            {
                Console.WriteLine(p);
            }

            Dog myDog = new Dog();

            myDog.myMethod();

        }
    }
}
