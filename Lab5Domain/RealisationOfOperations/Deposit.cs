using Lab5Domain.Entities;
using Lab5Domain.ResultTypes;

namespace Lab5Domain.RealisationOfOperations;

public class Deposit : IDoOperation
{
    private readonly IAccount _account;

    public Deposit(IAccount account)
    {
        _account = account;
    }

    public TypesOfResult Doing(decimal amount)
    {
        if (amount <= 0)
        {
            return new TypesOfResult.Fail("Сумма должна быть положительной");
        }

        _account.Balance += amount;
        return new TypesOfResult.Success();
    }
}