using Lab5Domain.Entities;
using Lab5Domain.Ports;
using Npgsql;
using System.Collections.ObjectModel;
using System.Data;

namespace Lab5Infrastructure.Adapters;

public class TransactionRepository : ITransactionRepository
{
    private readonly NpgsqlConnection _connection;

    public TransactionRepository(NpgsqlConnection connection)
    {
        _connection = connection;
    }

    public Collection<MoneyTransactions>? FindTransactionByNumber(int accountNumber)
    {
        if (_connection.State == ConnectionState.Closed)
        {
            _connection.Open();
        }

        const string sql = "SELECT * FROM Transactions WHERE accountNumber = @accountNumber ORDER BY transactionTime DESC";
        var command = new NpgsqlCommand(sql, _connection);
        command.Parameters.AddWithValue("@accountNumber", accountNumber);
        using NpgsqlDataReader reader = command.ExecuteReader();

        var transactions = new Collection<MoneyTransactions>();
        while (reader.Read())
        {
            string operationType = reader.GetString(1);
            var currentTransaction = new MoneyTransactions(operationType, accountNumber, reader.GetDecimal(2));
            currentTransaction.Time = reader.GetTimeSpan(0);
            transactions.Add(currentTransaction);
        }

        return transactions.Count > 0 ? transactions : null;
    }

    public void Save(MoneyTransactions transaction)
    {
        if (_connection.State == ConnectionState.Closed)
        {
            _connection.Open();
        }

        const string sql = "INSERT INTO transactions (transactionTime, operationType, amount, accountNumber, transactionNumber) VALUES (@transactionTime, @operationType, @amount, @accountNumber, @transactionNumber)";
        var command = new NpgsqlCommand(sql, _connection);
        command.Parameters.AddWithValue("@transactionTime", transaction.Time);
        command.Parameters.AddWithValue("@operationType", transaction.OperationType);
        command.Parameters.AddWithValue("@amount", transaction.Amount);
        command.Parameters.AddWithValue("@accountNumber", transaction.AccountNumber);
        command.Parameters.AddWithValue("@transactionNumber", transaction.TransactionNumber);
        command.ExecuteNonQuery();
    }
}