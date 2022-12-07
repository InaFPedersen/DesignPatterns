using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    /// <summary>
    /// Context
    /// </summary>
    public class BankAccount
    {
        public BankAccountState BankAccountState { get; set; }

        public decimal Balance { get { return BankAccountState.Balance; } }

        public BankAccount()
        {
            BankAccountState = new RegularState(200, this);
        }

        public void Deposit(decimal amount)
        {
            //let the current state handle the deposit
            BankAccountState.Deposit(amount);
        }

        public void Withdraw(decimal amount)
        {
            //let the current state handle the withdraw
            BankAccountState.Withdraw(amount);

        }

    }
}
