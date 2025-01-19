using Lab5Application;
using Lab5Domain.Entities;
using Lab5Domain.ResultTypes;

namespace Lab5ConsoleApp.ConsoleOperations;

public class WithdrawConsoleService
{
    private readonly IBankService _bankService;

    private WithdrawConsoleService(IBankService bankService)
    {
        _bankService = bankService;
    }

    public static WithdrawConsoleService Create(IBankService bankService)
    {
        return new WithdrawConsoleService(bankService);
    }

    public void Do(string? amount, IAccount account)
    {
        if (amount == null || !decimal.TryParse(amount, out decimal amountDecimal))
        {
            Console.WriteLine("Некорректный ввод.");
            return;
        }

        TypesOfResult wResult = _bankService.Withdraw(account.Number, amountDecimal);
        Console.WriteLine(wResult is TypesOfResult.Success ? "Операция успешна" : "Ошибка операции");
    }
}