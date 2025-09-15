using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_1
{
    abstract class BankAccount
    {
        public int Id { get; }
        public decimal Balance { get; protected set; }
        public static decimal TotalBalance { get; protected set; }
        public decimal WithdrawnThisSession { get; private set; }

        protected BankAccount(int id, decimal initialBalance = 0)
        {
            Id = id;
            Balance = initialBalance;
            TotalBalance += initialBalance;
        }

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be positive");
            }

            Balance += amount;
            TotalBalance += amount;

            if (amount > 1_000_000)
            {
                DebitAccount debit = accounts.OfType<DebitAccount>().FirstOrDefault();
                debit?.Deposit(2000);
            }
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be positive");
            }
            if (amount > 30000)
            {
                throw new InvalidOperationException("You cannot withdraw more than 30000 one time");
            }

            Balance -= amount;
            WithdrawnThisSession += amount;
            TotalBalance -= amount;
        }

        public override string ToString()
        {
            return $"{GetType().Name} (ID: {Id}), balance: {Balance}.";
        }
    }
}
