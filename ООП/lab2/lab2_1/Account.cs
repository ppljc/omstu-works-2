using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_1
{
    abstract class Account
    {
        public int Id { get; }
        public decimal Balance { get; protected set; }

        protected abstract string AccountType { get; }

        public Account(int id, decimal balance = 0)
        {
            Id = id;
            Balance = balance;
        }

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сумма должна быть положительной.");
            Balance += amount;
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сумма должна быть положительной.");
            Balance -= amount;
        }

        public override string ToString()
        {
            return $"ID {Id}, {GetType().Name}, баланс: {Balance}";
        }
    }
}
