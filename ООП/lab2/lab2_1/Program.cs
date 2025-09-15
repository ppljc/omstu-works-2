using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            ATM atm = new ATM();

            var debit = new DebitAccount(1, 5000);
            var credit = new CreditAccount(2, 0);

            atm.AddAccount(debit);
            atm.AddAccount(credit);

            bool exit = false;
            while (!exit)
            {
                atm.PrintAccounts();
                Console.WriteLine($"Current account: {atm.ActiveAccount.Id} ({atm.ActiveAccount.GetType().Name})\n");

                Console.WriteLine("Menu:");
                Console.WriteLine("1. Deposit money");
                Console.WriteLine("2. Withdraw money");
                Console.WriteLine("3. Transfer money");
                Console.WriteLine("4. Change current account");
                Console.WriteLine("0. Exit");

                Console.Write("Choose action: ");
                var choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Amount: ");
                            decimal depSum = decimal.Parse(Console.ReadLine());
                            atm.ActiveAccount.Deposit(depSum);
                            break;

                        case "2":
                            Console.Write("Amount: ");
                            decimal witSum = decimal.Parse(Console.ReadLine());
                            atm.ActiveAccount.Withdraw(witSum);
                            break;

                        case "3":
                            Console.Write("Incoming account ID: ");
                            int toId = int.Parse(Console.ReadLine());
                            Console.Write("Amount: ");
                            decimal transSum = decimal.Parse(Console.ReadLine());
                            atm.Transfer(atm.ActiveAccount, atm.GetAccountById(toId), transSum);
                            break;

                        case "4":
                            Console.Write("Enter new current account ID: ");
                            int newActiveId = int.Parse(Console.ReadLine());
                            atm.SetActiveAccount(newActiveId);
                            break;

                        case "0":
                            exit = true;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n ! Error: {ex.Message}\n");
                }
            }
        }
    }
}
