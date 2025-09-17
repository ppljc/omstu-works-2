using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_1
{
    sealed class CreditAccount : Account
    {
        protected override string AccountType => "Кредитный счёт";

        public CreditAccount(int id, decimal balance = 0) : base(id, balance) { }
    }
}
