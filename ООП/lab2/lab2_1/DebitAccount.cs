using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_1
{
    sealed class DebitAccount : BankAccount
    {
        public DebitAccount(int id, decimal balance = 0) : base(id, balance) { }

        public override void Withdraw(decimal amount)
        {
            if (amount > 30000)
            { 
                throw new InvalidOperationException("You cannot withdraw more than 30000 one time");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("You cannot go under 0 on debit account");
            }

            Balance -= amount;
            TotalBalance -= amount;
        }
    }
}
