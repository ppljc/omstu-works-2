using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_1
{
    class Card
    {
        public string Number { get; }
        public string Pin { get; }
        public List<Account> Accounts { get; }

        public Card(string number, string pin, List<Account> accounts)
        {
            Number = number;
            Pin = pin;
            Accounts = accounts;
        }

        public Account ActiveAccount => Accounts[0];
        public decimal TotalBalance => Accounts.Sum(a => a.Balance);

        public void PrintCardInfo()
        {
            Console.WriteLine($"Ваша карта: {Number}");
            Console.WriteLine($"Активный счёт: {Accounts[0]}");
            Console.WriteLine("Все счета:");
            for (int i = 0; i < Accounts.Count; i++)
                Console.WriteLine(Accounts[i]);
            Console.WriteLine($"Сумма всех счетов: {TotalBalance}");
        }
    }
}
