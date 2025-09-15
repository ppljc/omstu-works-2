using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_1
{
    sealed class CurrentAccount : BankAccount
    {
        public CurrentAccount(int id, decimal balance = 0) : base(id, balance) { }
    }
}
