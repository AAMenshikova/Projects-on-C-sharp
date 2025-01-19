using Lab5Domain.Entities;
using Lab5Domain.ResultTypes;
using System.Collections.ObjectModel;

namespace Lab5Application;

public interface IBankService
{
    IAccount CreateAccount(int number, int pin);

    TypesOfResult Deposit(int accountNumber, decimal amount);

    TypesOfResult Withdraw(int accountNumber, decimal amount);

    Collection<MoneyTransactions>? GetTransactionsHistory(int accountNumber);
}