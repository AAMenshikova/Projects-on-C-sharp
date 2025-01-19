using Lab5Domain.Entities;
using Lab5Domain.ResultTypes;

namespace Lab5Domain.RealisationOfOperations;

public class Withdraw : IDoOperation
{
    private readonly IAccount _account;

    public Withdraw(IAccount account)
    {
        _account = account;
    }

    public TypesOfResult Doing(decimal amount)
    {
        if (amount <= 0 || amount > _account.Balance)
        {
            return new TypesOfResult.Fail("Некорректное значение суммы");
        }

        _account.Balance -= amount;
        return new TypesOfResult.Success();
    }
}