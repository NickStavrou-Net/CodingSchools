using DesignPatterns.Factory_Pattern;
using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            string setting = "mysql";

            DBFactory dBFactory = new(setting);
            IDatabase<Product> dbHandler = dBFactory.GetDatabase<Product>();

            Product p = new();

            switch (setting)
            {
                case "mssql":
                    MsSQL<Product> mssql = new();
                    mssql.Add(p);
                    break;
                case "mongodb":
                    MongoDB<Product> mongo = new();
                    mongo.Add(p);
                    break;
            }



            dbHandler.Add(p);

            Console.ReadLine();

        }
    }
    
}
