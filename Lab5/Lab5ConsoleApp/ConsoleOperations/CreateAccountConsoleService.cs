using Lab5Application;
using Lab5Domain.Ports;

namespace Lab5ConsoleApp.ConsoleOperations;

public class CreateAccountConsoleService
{
    private readonly IBankService _bankService;
    private readonly IAccountRepository _accountRepository;

    private CreateAccountConsoleService(IBankService bankService, IAccountRepository accountRepository)
    {
        _bankService = bankService;
        _accountRepository = accountRepository;
    }

    public static CreateAccountConsoleService Create(IBankService bankService, IAccountRepository accountRepository)
    {
        return new CreateAccountConsoleService(bankService, accountRepository);
    }

    public void Do()
    {
        Console.WriteLine("Введите номер нового счета: ");
        string? number = Console.ReadLine();
        if (number == null)
        {
            Console.WriteLine("Некорректный ввод.");
            return;
        }

        int accountNumber = int.Parse(number);
        if (_accountRepository.FindAccountByNumber(accountNumber) is not null)
        {
            Console.WriteLine("Аккаунт с таким номером уже существует.");
            return;
        }

        Console.WriteLine("Введите пин нового счета: ");
        string? pin = Console.ReadLine();
        if (pin == null)
        {
            Console.WriteLine("Некорректный ввод.");
            return;
        }

        int accountPin = int.Parse(pin);
        _bankService.CreateAccount(accountNumber, accountPin);
        Console.WriteLine("Новый счет успешно создан!");
    }
}