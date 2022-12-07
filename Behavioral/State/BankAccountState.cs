using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    /// <summary>
    /// State
    /// </summary>
    public abstract class BankAccountState
    {
        public BankAccount BankAccount { get; protected set; } = null!;

        public decimal Balance { get; protected set; }

        public abstract void Deposit(decimal amount);

        public abstract void Withdraw(decimal amount);
    }
}
