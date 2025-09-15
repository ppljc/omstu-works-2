using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace lab2_1
{
    class ATM
    {
        private List<BankAccount> accounts = new List<BankAccount>();

        public BankAccount ActiveAccount { get; private set; }

        public void AddAccount(BankAccount acc)
        {
            accounts.Add(acc);

            if (ActiveAccount == null)
            { 
                ActiveAccount = acc;
            }
        }

        public void SetActiveAccount(int id)
        {
            var acc = accounts.Find(a => a.Id == id);
            if (acc == null)
            {
                throw new ArgumentException("Счёт с таким ID не найден");
            }
            ActiveAccount = acc;
        }

        public void Transfer(BankAccount outcomingAccount, BankAccount incomingAccount, decimal amount)
        {
            if (outcomingAccount is DebitAccount && HasBadCredit())
            {
                throw new InvalidOperationException("You cannot interact with debit account with duty more than 20000");
            }

            outcomingAccount.Withdraw(amount);
            incomingAccount.Deposit(amount)
        }

        private bool HasBadCredit()
        {
            foreach (var acc in accounts)
            {
                if (acc is CreditAccount && acc.Balance < -20000)
                    return true;
            }
            return false;
        }

        public BankAccount GetAccountById(int id)
        { 
            return accounts.Find(a => a.Id == id);
        }

        public void PrintAccounts()
        {
            foreach (var acc in accounts)
                Console.WriteLine(acc);
            Console.WriteLine($"Total balance: {BankAccount.TotalBalance}\n");
        }
    }
}
