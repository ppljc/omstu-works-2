using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_1
{
    sealed class DebitAccount : Account
    {
        protected override string AccountType => "Дебетовый счёт";

        public DebitAccount(int id, decimal balance = 0) : base(id, balance) { }

        public override void Withdraw(decimal amount)
        {
            if (Balance - amount < 0)
                throw new InvalidOperationException("Нельзя уйти в минус на дебетовом счёте.");
            base.Withdraw(amount);
        }
    }
}
