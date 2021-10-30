using DesignPatterns.Factory_Pattern;
using DesignPatterns.Singleton;
using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            #region FactoryPattern
            //string setting = "mysql";

            //DBFactory dBFactory = new(setting);
            //IDatabase<Product> dbHandler = dBFactory.GetDatabase<Product>();

            //Product p = new();

            //switch (setting)
            //{
            //    case "mssql":
            //        MsSQL<Product> mssql = new();
            //        mssql.Add(p);
            //        break;
            //    case "mongodb":
            //        MongoDB<Product> mongo = new();
            //        mongo.Add(p);
            //        break;
            //}
            //dbHandler.Add(p);
            #endregion
            #region ObserverPattern

            #endregion
            #region SingletonPattern
            DBManager dBManager = DBManager.Instance;
            dBManager.GetConnection();
            #endregion
            Console.ReadLine();

        }
    }
    
}
