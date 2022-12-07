using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    /// <summary>
    /// Concrete State
    /// </summary>
    public class RegularState : BankAccountState
    {
        public RegularState(decimal balance, BankAccount bankAccount)
        {
            Balance = balance;
            BankAccount = bankAccount;
        }

        public override void Deposit(decimal amount)
        {
            Console.WriteLine($"In {GetType()}, depositing {amount}");
            Balance += amount;

            if (Balance >= 1000)
            {
                //Change to gold state
                BankAccount.BankAccountState = new GoldState(Balance, BankAccount);
            }
        }

        public override void Withdraw(decimal amount)
        {
            Console.WriteLine($"In {GetType()}, withdrawing {amount} from {Balance}");
            //Change state to overdrawn when withdrawing results in less than zero
            Balance -= amount;

            if (Balance < 0)
            {
                //Change state to overdrawn
                BankAccount.BankAccountState = new OverdrawnState(Balance, BankAccount);
            }
        }


    }
}
