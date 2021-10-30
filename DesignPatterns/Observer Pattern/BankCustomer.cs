using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Observer_Pattern
{
    public class BankCustomer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public BankCustomer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void Notify(IAccount account) => Console.WriteLine($@"SMS Notification for {FirstName} {LastName}: 
                                 The amount of account with IBAN {account.IBAN} 
                                 changed to {string.Format("{0:0.00} EUR", account.GetBalance())}");
    }
}
