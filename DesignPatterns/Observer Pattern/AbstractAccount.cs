using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Observer_Pattern
{
    public abstract class AbstractAccount : IAccount
    {
        private readonly List<IBeneficiary> _accountBeneficiaries = new();

        public string IBAN { get; set; }

        public void Attach(IBeneficiary beneficiary)
        {
            if (!_accountBeneficiaries.Contains(beneficiary))
            {
                _accountBeneficiaries.Add(beneficiary);
            }
        }

        public void Detach(IBeneficiary beneficiary)
        {
            _accountBeneficiaries.Remove(beneficiary);
        }

        public void Notify()
        {
            foreach (IBeneficiary beneficiary in _accountBeneficiaries)
            {
                beneficiary.Notify(this);
            }
        }

        // methods to be implemented with specific type of accounts
        public abstract void Withdraw(double amount);
        public abstract void Deposit(double amount);
        public abstract double GetBalance();
    }
}
