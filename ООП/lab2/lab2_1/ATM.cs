using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_1
{
    class ATM
    {
        private List<Card> cards = new List<Card>();
        private Card currentCard = null;
        private decimal withdrawnThisSession = 0;

        public ATM()
        {
            // Заготовленные карты
            cards.Add(new Card("1234123412341234", "1234",
                new List<Account> { new DebitAccount(0, 10000), new CreditAccount(1, -5000) }));
            cards.Add(new Card("1111222233334444", "1111",
                new List<Account> { new DebitAccount(0, 500000) }));
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Главное меню ===");
                Console.WriteLine("1. Новый сеанс");
                Console.WriteLine("2. Выйти");
                Console.Write("Ввод: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    StartSession();
                }
                else if (choice == "2")
                {
                    break;
                }
            }
        }

        private void StartSession()
        {
            Console.Clear();
            Console.WriteLine("Введите номер карты (16 символов):");
            Console.Write("Ввод: ");
            string number = Console.ReadLine();

            Card card = cards.FirstOrDefault(c => c.Number == number);
            if (card == null)
            {
                Console.WriteLine("Такой карты не существует.");
                Console.WriteLine("Нажмите любую клавишу для возврата...");
                Console.ReadKey();
                return;
            }

            int attempts = 3;
            while (attempts > 0)
            {
                Console.WriteLine("Введите PIN (4 символа):");
                Console.Write("Ввод: ");
                string pin = Console.ReadLine();
                if (card.Pin == pin)
                {
                    currentCard = card;
                    withdrawnThisSession = 0;
                    SessionMenu();
                    return;
                }
                else
                {
                    attempts--;
                    if (attempts > 0)
                    {
                        Console.WriteLine("Неверный PIN. Осталось попыток: " + attempts);
                        Console.WriteLine("1. Ввести пароль снова");
                        Console.WriteLine("2. Вернуться в главное меню");
                        Console.Write("Ввод: ");
                        string choice = Console.ReadLine();
                        if (choice == "2") 
                            return;
                    }
                    else
                    {
                        Console.WriteLine("Ваша карта заблокирована, 40 волков уже выехало, вопрос будем решать тихо мирно по телефону?!");
                        Console.WriteLine("Нажмите любую клавишу для закрытия окна...");
                        Environment.Exit(0);
                    }
                }
            }
        }

        private void SessionMenu()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    currentCard.PrintCardInfo();

                    Console.WriteLine("\n=== Меню сеанса ===");
                    Console.WriteLine("1. Создать новый счёт");
                    if (currentCard.Accounts.Count > 1)
                    {
                        Console.WriteLine("2. Выбрать активный счёт");
                        Console.WriteLine("3. Перевод");
                    }
                    Console.WriteLine("4. Пополнить");
                    Console.WriteLine("5. Снять");
                    Console.WriteLine("6. Выйти в главное меню");
                    Console.Write("Ввод: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1": CreateAccount(); break;
                        case "2": if (currentCard.Accounts.Count > 1) SelectActiveAccount(); break;
                        case "3": if (currentCard.Accounts.Count > 1) Transfer(); break;
                        case "4": Deposit(); break;
                        case "5": Withdraw(); break;
                        case "6": return;
                    }
                } catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                    Console.WriteLine("Нажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                }
            }
        }

        private void CreateAccount()
        {
            Console.WriteLine("Выберите тип счёта:");
            Console.WriteLine("1. Дебетовый");
            Console.WriteLine("2. Кредитный");
            Console.WriteLine("3. Отмена");
            Console.Write("Ввод: ");
            string choice = Console.ReadLine();
            int newId = currentCard.Accounts.Count;

            if (choice == "1")
                currentCard.Accounts.Add(new DebitAccount(newId));
            else if (choice == "2")
                currentCard.Accounts.Add(new CreditAccount(newId));
        }

        private void SelectActiveAccount()
        {
            Console.WriteLine("Выберите счёт по ID:");
            for (int i = 0; i < currentCard.Accounts.Count; i++)
                Console.WriteLine($"{i}) {currentCard.Accounts[i]}");
            Console.Write("Ввод: ");
            if (int.TryParse(Console.ReadLine(), out int id) && id >= 0 && id < currentCard.Accounts.Count)
            {
                var selected = currentCard.Accounts[id];
                currentCard.Accounts.RemoveAt(id);
                currentCard.Accounts.Insert(0, selected);
            }
        }

        private void Transfer()
        {
            Console.WriteLine("Введите ID счёта, на который перевести:");
            for (int i = 0; i < currentCard.Accounts.Count; i++)
                Console.WriteLine($"{i}) {currentCard.Accounts[i]}");
            Console.Write("Ввод: ");
            if (int.TryParse(Console.ReadLine(), out int id) && id > 0 && id < currentCard.Accounts.Count)
            {
                Console.WriteLine("Введите сумму:");
                Console.Write("Ввод: ");
                decimal amount = decimal.Parse(Console.ReadLine());
                currentCard.ActiveAccount.Withdraw(amount);
                currentCard.Accounts[id].Deposit(amount);
            }
        }

        private void Deposit()
        {
            Console.WriteLine("Введите сумму:");
            Console.Write("Ввод: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            currentCard.ActiveAccount.Deposit(amount);

            if (amount > 1_000_000)
            {
                var debit = currentCard.Accounts.FirstOrDefault(a => a is DebitAccount);
                if (debit != null)
                {
                    debit.Deposit(2000);
                }
            }
        }

        private void Withdraw()
        {
            Console.WriteLine("Введите сумму:");
            Console.Write("Ввод: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            if (withdrawnThisSession + amount > 30000)
            {
                Console.WriteLine("Нельзя снять больше 30000 за сеанс.");
                Console.WriteLine("Нажмите любую клавишу для возврата...");
                Console.ReadKey();
                return;
            }
            currentCard.ActiveAccount.Withdraw(amount);
            withdrawnThisSession += amount;
        }
    }
}
