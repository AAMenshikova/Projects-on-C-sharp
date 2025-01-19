using AllMigrations;
using Lab5Application;
using Lab5ConsoleApp.ConsoleOperations;
using Lab5Domain.Entities;
using Lab5Infrastructure.Adapters;
using Npgsql;
using System.Collections.ObjectModel;

namespace Lab5ConsoleApp;

public class Program
{
    public static void Main()
    {
        string connectionString = "Host=localhost;Port=6432;Database=postgres;Username=postgres;Password=Nastya1233";
        Console.WriteLine("Введите системный пароль для администратора: ");
        string? myPassword = Console.ReadLine();
        if (myPassword == null)
        {
            Console.WriteLine("Некорректный ввод.");
        }

        var connection = new NpgsqlConnection(connectionString);
        new CreatingTables().Up(connectionString);
        var accountRepository = new AccountRepository(connection);
        var transactionRepository = new TransactionRepository(connection);
        var bankService = new BankService(accountRepository, transactionRepository);

        Console.WriteLine("Выберите режим работы (пользователь: п / администратор: а): ");
        string? input = Console.ReadLine();
        if (input == null || (input != "п" && input != "а"))
        {
            Console.WriteLine("Некорректный ввод.");
            return;
        }

        if (input == "п")
        {
            int numberAcc = UserRegime.Go(accountRepository);
            if (numberAcc == 0)
            {
                return;
            }

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Выберите операцию: ");
                Console.WriteLine("1. Просмотр баланса");
                Console.WriteLine("2. Снятие денег");
                Console.WriteLine("3. Пополнение счета");
                Console.WriteLine("4. История операций");
                Console.WriteLine("5. Выход");
                string? operation = Console.ReadLine();
                if (operation == null || (operation != "1" && operation != "2" && operation != "3" && operation != "4" && operation != "5"))
                {
                    Console.WriteLine("Некорректный ввод.");
                    return;
                }

                IAccount? account1 = accountRepository.FindAccountByNumber(numberAcc);
                if (account1 == null)
                {
                    Console.WriteLine("Произошла ошибка. Такого счета не существует.");
                    return;
                }

                switch (operation)
                {
                    case "1":
                        Console.WriteLine($"Баланс = {account1.Balance}");
                        break;
                    case "2":
                        Console.WriteLine("Введите сумму, которую хотите снять: ");
                        string? amount = Console.ReadLine();
                        if (amount != null)
                        {
                            var withdrawConsoleService = WithdrawConsoleService.Create(bankService);
                            withdrawConsoleService.Do(amount, account1);
                        }

                        break;
                    case "3":
                        Console.WriteLine("Введите сумму, которую хотите положить: ");
                        string? amount1 = Console.ReadLine();
                        var depositConsoleService = DepositConsoleService.Create(bankService);
                        depositConsoleService.Do(amount1, account1);
                        break;
                    case "4":
                        Collection<MoneyTransactions>? history = bankService.GetTransactionsHistory(account1.Number);
                        GetHistoryOfTransactionsConsoleService.Do(history);
                        break;
                    case "5":
                        Console.WriteLine("Окончание работы.");
                        exit = true;
                        break;
                }
            }
        }

        if (input == "а")
        {
            Console.WriteLine("Выбран режим администратора. Укажите системный пароль: ");
            string? systemPassword = Console.ReadLine();
            if (systemPassword == null)
            {
                Console.WriteLine("Некорректный ввод.");
                return;
            }

            if (systemPassword != myPassword)
            {
                Console.WriteLine("Неверный пароль.");
                return;
            }

            var createAccount = CreateAccountConsoleService.Create(bankService, accountRepository);
            createAccount.Do();
        }
    }
}