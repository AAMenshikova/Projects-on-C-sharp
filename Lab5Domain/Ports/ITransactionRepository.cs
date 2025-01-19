using Lab5Domain.Entities;
using System.Collections.ObjectModel;

namespace Lab5Domain.Ports;

public interface ITransactionRepository
{
    Collection<MoneyTransactions>? FindTransactionByNumber(int accountNumber);

    void Save(MoneyTransactions transaction);
}