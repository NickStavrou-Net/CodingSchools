using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Observer_Pattern
{
    public class SavingsAccount : AbstractAccount
    {

        private double balance;

        public override void Deposit(double amount)
        {
            this.balance += amount;
            Notify();   // Notify all beneficiaries of the Deposit
        }

        public override double GetBalance()
        {
            return this.balance;
        }

        public override void Withdraw(double amount)
        {
            if(balance-amount < 0)
            {
                throw new InsufficientFundsException("You don't have enough money!");
            } 
            else
            {
                this.balance -= amount;
                Notify();   // Notify all beneficiaries of the Withdrawal
            }
        }
    }
}
