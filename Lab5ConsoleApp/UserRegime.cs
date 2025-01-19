using Lab5Domain.Entities;
using Lab5Domain.Ports;

namespace Lab5ConsoleApp;

public class UserRegime
{
    public static int Go(IAccountRepository accountRepository)
    {
        Console.WriteLine("Выбран режим пользователя. Укажите номер счета: ");
        string? accountNumber = Console.ReadLine();
        if (accountNumber == null)
        {
            Console.WriteLine("Некорректный ввод.");
            return 0;
        }

        if (!int.TryParse(accountNumber, out int numberAcc))
        {
            Console.WriteLine("Некорректный формат ввода.");
            return 0;
        }

        IAccount? acc = accountRepository.FindAccountByNumber(numberAcc);
        if (acc == null)
        {
            Console.WriteLine("Аккаунта с таким номером счета не существует.");
            return 0;
        }

        Console.WriteLine("Введите пин: ");
        string? pin = Console.ReadLine();
        if (pin == null)
        {
            Console.WriteLine("Некорректный ввод.");
            return 0;
        }

        if (!int.TryParse(pin, out int pinAcc))
        {
            Console.WriteLine("Некорректный формат ввода.");
            return 0;
        }

        if (acc.Pin != pinAcc)
        {
            Console.WriteLine("Неверный пин.");
            return 0;
        }

        return numberAcc;
    }
}