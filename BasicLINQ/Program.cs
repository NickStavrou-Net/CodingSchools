using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ages = new int[] { 8, 10, 12, 16, 18, 25, 30, 42, 59, 70 };
            int countAdults = (from age in ages where age >= 18 select age).Count();

            Console.WriteLine("Count of Adults: " + countAdults);

            IEnumerable<int> adults =   // Can also work with var instead of IEnumerable
                (from age in ages
                 where age >= 18
                 orderby age descending // Optional: sort results ascending or descending
                 select age);    // You can put .ToList() after closing parenthesis to execute

            foreach (int i in adults)   // Can also work with var instead of int
                Console.WriteLine(i + " ");		// Will print 18 25 30 42 59 70

            int maxAdultAge = (from age in ages where age >= 18 select age).Max();
            int minAdultAge = (from age in ages where age >= 18 select age).Min();
            double avgAge = (from age in ages select age).Average();

            string result = String.Format("Max Adult Age: {0:d}\tMin Adult Age: {1:d}\tAvg Age: {2:f}", maxAdultAge, minAdultAge, avgAge);
            Console.WriteLine(result);

            List<Country> countries = new List<Country>();
            countries.Add(new Country { Name = "Greece", Population = 10000000, Cities = { new City { Name = "Athens", Population = 664046 }, new City { Name = "Patra", Population = 167446 } } });
            countries.Add(new Country { Name = "Italy", Population = 59000000, Cities = { new City { Name = "Rome", Population = 2800000 }, new City { Name = "Milan", Population = 3144473 } } });

            var citiesQuery =
                (from country in countries
                 from city in country.Cities
                 where city.Population > 500000
                 select city);

            foreach (var c in citiesQuery)
            {
                Console.WriteLine(c.Name);
            }

            var countriesQuery =
                (from country in countries
                 group country by country.Population
            );

            foreach (var c in countriesQuery)
            {
                Console.WriteLine(c.Key);
            }

            List<Category> categories = new List<Category>();
            categories.Add(new Category { Name = "Television" });
            categories.Add(new Category { Name = "Refrigerator" });
            categories.Add(new Category { Name = "Hifi" });

            List<Product> products = new List<Product>();
            products.Add(new Product { Name = "SONY TV", Category = categories.Where(c => c.Name.Equals("Television")).FirstOrDefault() });
            products.Add(new Product { Name = "LG", Category = categories.Where(c => c.Name.Equals("Refrigerator")).FirstOrDefault() });
            products.Add(new Product { Name = "AKAI", Category = categories.Where(c => c.Name.Equals("Hifi")).FirstOrDefault() });

            var productsQuery =
                (from cat in categories
                join prod in products on cat equals prod.Category
                select new { Category = cat.Name, Product = prod.Name });

            foreach(var p in productsQuery)
            {
                Console.WriteLine($"{p.Product} {p.Category}");
            }

            string[] names = { "George Sovatzis", "Nikos Stavrou", "Antonis Antoniou" };
            var queryFirstNames =
                (from name in names
                 let fName = name.Split(' ')[0]   // Splits name into array and gets 1st element
                select fName);

            foreach(var s in queryFirstNames)
            {
                Console.WriteLine(s);
            }

            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer { Cid = "0001", FirstName = "George", LastName = "Sovatzis" });
            customers.Add(new Customer { Cid = "0002", FirstName = "Nikos", LastName = "Stavrou" });
            customers.Add(new Customer { Cid = "0003", FirstName = "Antonis", LastName = "Antoniou" });

            List<Sale> sales = new List<Sale>();
            sales.Add(new Sale { Cid = "0001", Amount = 500 });
            sales.Add(new Sale { Cid = "0002", Amount = 1500 });
            sales.Add(new Sale { Cid = "0003", Amount = 1000 });

            var bigSaleCustomers =   // Get all customers with any purchase more than 1000 Euros
                (from c in customers
                 select new
                 {
                     c.FirstName,
                     c.LastName,
                     Sales = (from s in sales where s.Cid == c.Cid && s.Amount > 1000 select s)
                 }
                ).Where(x => x.Sales.Count() > 0);

            foreach(var bc in bigSaleCustomers)
            {
                Console.WriteLine($"{bc.FirstName} {bc.LastName}");
            }

        }
    }
}
