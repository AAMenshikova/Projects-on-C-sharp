using Lab5Application;
using Lab5Domain.Entities;
using Lab5Domain.ResultTypes;

namespace Lab5ConsoleApp.ConsoleOperations;

public class DepositConsoleService
{
    private readonly IBankService _bankService;

    private DepositConsoleService(IBankService bankService)
    {
        _bankService = bankService;
    }

    public static DepositConsoleService Create(IBankService bankService)
    {
        return new DepositConsoleService(bankService);
    }

    public void Do(string? amount, IAccount account)
    {
        if (amount == null || !decimal.TryParse(amount, out decimal amountDecimal1))
        {
            Console.WriteLine("Некорректный ввод.");
            return;
        }

        TypesOfResult dResult1 = _bankService.Deposit(account.Number, amountDecimal1);
        Console.WriteLine(dResult1 is TypesOfResult.Success ? "Операция успешна" : "Ошибка операции");
    }
}