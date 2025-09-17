using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace lab2_1
{
    class Bank
    {
        public List<Card> Cards { get; } = new List<Card>();

        private decimal withdrawnThisSession = 0;

        public Card FindCard(string number)
        {
            return Cards.Find(c => c.Number == number);
        }

        public void ResetSessionLimit()
        {
            withdrawnThisSession = 0;
        }

        public void Withdraw(Account acc, decimal amount)
        {
            if (withdrawnThisSession + amount > 30000)
                throw new InvalidOperationException("За один сеанс нельзя снять более 30 000");

            acc.Withdraw(amount);
            withdrawnThisSession += amount;
        }
    }
}
