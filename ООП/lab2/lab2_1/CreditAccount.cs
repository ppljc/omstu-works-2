using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_1
{
    sealed class CreditAccount : BankAccount
    {
        public CreditAccount(int id, decimal balance = 0) : base(id, balance) { }

        public override void Withdraw(decimal amount)
        {
            if (amount > 30000)
            {
                throw new InvalidOperationException("You cannot withdraw more than 30000 one time");
            }

            Balance -= amount;
            TotalBalance -= amount;
        }
    }
}
