using Lab5Domain.Entities;

namespace Lab5ConsoleApp.ConsoleOperations;

public class GetHistoryOfTransactionsConsoleService
{
    public static void Do(IEnumerable<MoneyTransactions>? history)
    {
        if (history == null)
        {
            Console.WriteLine("История пуста.");
        }
        else
        {
            foreach (MoneyTransactions transaction in history)
            {
                Console.WriteLine($"{transaction.Time}, {transaction.OperationType}, {transaction.Amount}, {transaction.AccountNumber}, {transaction.TransactionNumber}");
            }
        }
    }
}