using DesignPatterns.Builder_Pattern;
using DesignPatterns.Factory_Pattern;
using DesignPatterns.Observer_Pattern;
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

            //IBeneficiary george = new BankCustomer("George", "Sovatzis");
            //IBeneficiary rose = new BankCustomer("Rose", "Daponte");
            //IBeneficiary elias = new BankCustomer("Elias", "Sovatzis");

            //SavingsAccount myAccount = new SavingsAccount { IBAN="GR58 0000 3000 5000" };
            //myAccount.Attach(rose);
            //myAccount.Attach(elias);

            //myAccount.Deposit(100);
            //myAccount.Detach(elias);
            //myAccount.Withdraw(50);


            #endregion

            #region SingletonPattern
            //DBManager dBManager = DBManager.Instance;
            //dBManager.GetConnection();
            #endregion

            #region BuilderPattern
            //TODO return ADO.NET sql connection string
            FluentSqlConnection
                .CreateConnection(config => config.ConnectionName = "Nick Connection")
                .ForServer("(localdb)\\MSSQLLocalDB")
                .AndDatabase("CSVDatabase")
                .AsUser("DESKTOP-6VLMGU5\\NickStavrou")
                .WithPassword("")
                .Connect();
            #endregion


        }
    }
    
}
